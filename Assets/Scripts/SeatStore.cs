using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
BUGS:
- You seem to be able to go past last index, and the whole thing breaks (investigate);
*/

public class SeatStore : MonoBehaviour
{

    [SerializeField] DebugTextMesh debugTextMesh;

    [SerializeField] List<Transform> seats;
    [SerializeField] List<Transform> avatars;

    [SerializeField] InputAction movement;

    public int debugCounterInt = 0;
    public float debugCounterFloat = 0f;

    int indexOfPlayer = 0;
    float lastJoystickTilt = 0;

    void Start()
    {
        AssignSeats();
        movement.Enable();
    }

    void AssignSeats()
    {

        int firstOccupiedSeatIndex = 0;
        int numberOfPlayers = avatars.Count;

        /*
            1. Find indexOfPlayer
        */
        for (int i = 0; i < avatars.Count; i++)
        {
            if (avatars[i].tag == "Player")
            {
                indexOfPlayer = i;
            }
        }
        // debugTextMesh.label.text = $"{indexOfPlayer}";

        /*
            2. Assign seats with Player always at the center
        */
        for (int i = 0; i < avatars.Count; i++)
        {
            int seatIndex = 6 - indexOfPlayer + i;
            if (i == 0)
            {
                firstOccupiedSeatIndex = seatIndex;
            }
            avatars[i].position = seats[seatIndex].position;
            avatars[i].position = new Vector3(seats[seatIndex].position.x, seats[seatIndex].position.y + 1f, seats[seatIndex].position.z);
        }

        /*
            3. Remove mesh from seats that are not occupied
        */
        for (int i = 0; i < seats.Count; i++)
        {
            MeshRenderer seatMesh = seats[i].GetComponent<MeshRenderer>();
            if (i < firstOccupiedSeatIndex || i > numberOfPlayers - .6f + firstOccupiedSeatIndex)
            {
                seatMesh.enabled = false;
            }
            else
            {
                seatMesh.enabled = true;
            }
        }

        /*
            4. Remove mesh from the player’s object
        */
        MeshRenderer playerMesh = avatars[indexOfPlayer].GetComponent<MeshRenderer>();
        playerMesh.enabled = false;
    }

    void Update()
    {
        float joystickTilt = movement.ReadValue<Vector2>().x;
        if (Mathf.Abs(joystickTilt) > 0.5)
        {
            if (lastJoystickTilt == 0)
            {
                if (joystickTilt < 0f && indexOfPlayer > 0)
                {
                    Transform item = avatars[indexOfPlayer];
                    avatars.RemoveAt(indexOfPlayer);
                    avatars.Insert(indexOfPlayer - 1, item);
                    debugCounterInt = indexOfPlayer - 1;
                    AssignSeats();
                }
                else if (joystickTilt > 0f && indexOfPlayer < seats.Count - 1)
                {
                    Transform item = avatars[indexOfPlayer];
                    avatars.RemoveAt(indexOfPlayer);
                    avatars.Insert(indexOfPlayer + 1, item);
                    debugCounterInt = indexOfPlayer + 1;
                    AssignSeats();
                }
            }
            lastJoystickTilt = joystickTilt;
        } else {
            lastJoystickTilt = 0;
        }
    }

    void MoveToIndex(int index)
    {
        debugTextMesh.label.text = $"moving to {index}";
        Transform item = avatars[indexOfPlayer];
        avatars.RemoveAt(indexOfPlayer);
        avatars.Insert(index, item);
        AssignSeats();
    }

    public void SwitchPlacesWithIndex(int index)
    {
        MoveToIndex(index - (6 - indexOfPlayer));
    }
}
