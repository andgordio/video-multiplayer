using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CellController : MonoBehaviour
{
    [SerializeField] GameObject inviteButton;
    [SerializeField] GameObject inviteSentLabel;
    
    void Start()
    {
        inviteSentLabel.SetActive(false);
    }
    
    public void OnInviteButtonClick()
    {
        inviteButton.SetActive(false);
        inviteSentLabel.SetActive(true);
        Invoke("SimulateJoinedParty", 3f);
    }

    void SimulateJoinedParty()
    {
        TextMeshPro tmpro = inviteSentLabel.GetComponent<TextMeshPro>();
        tmpro.text = "In party";
        tmpro.color =  new Color(82f/255f, 185f/255f, 80f/255f);
    }
}
