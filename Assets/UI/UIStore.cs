using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStore : MonoBehaviour
{
    [SerializeField] Transform doc;
    [SerializeField] Transform party;
    [SerializeField] Transform invite;

    [SerializeField] GameObject partyHostAPartyContainer;
    [SerializeField] GameObject partyPartyViewContainer;

    void Start()
    {
        party.gameObject.SetActive(false);
        invite.gameObject.SetActive(false);
        partyPartyViewContainer.SetActive(false);
    }

    /*

        DOC

    */

    public void OnDocPartyButtonClick()
    {
        party.gameObject.SetActive(true);
    }

    /*

        PARTY VIEW

    */

    public void OnPartyCloseButtonClick()
    {
        party.gameObject.SetActive(false);
    }

    public void OnPartyCreatePartyButtonClick()
    {
        party.position = new Vector3(party.position.x, party.position.y, party.position.z + 0.2f);
        partyHostAPartyContainer.SetActive(false);
        partyPartyViewContainer.SetActive(true);

        invite.gameObject.SetActive(true);
    }

    public void OnInviteButtonClick()
    {
        invite.gameObject.SetActive(true);
        party.position = new Vector3(party.position.x, party.position.y, party.position.z + 0.2f);
    }

    /*

        INVITE VIEW

    */

    public void OnInviteCloseButtonClick()
    {
        invite.gameObject.SetActive(false);
        party.position = new Vector3(party.position.x, party.position.y, party.position.z - 0.2f);
    }
}
