using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTeleport : MonoBehaviour
{


    [SerializeField] DebugTextMesh debugTextMesh;
    [SerializeField] int index;

    void Start()
    {
    }

    public void ReactToTeleport()
    {
        SeatStore seatStore = FindObjectOfType<SeatStore>();
        // debugTextMesh.label.text = $"{index}";
        seatStore.SwitchPlacesWithIndex(index);
    }
}
