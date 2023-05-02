using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class syncGamestate : MonoBehaviour, IPunObservable
{
    GameObject session;
    // Start is called before the first frame update
    void Start()
    {
        session = GameObject.Find("Session");
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(session.GetComponent<SessionVariables>().NPCCount);
            stream.SendNext(session.GetComponent<SessionVariables>().HuntedCount);
            stream.SendNext(session.GetComponent<SessionVariables>().HunterCount);
            stream.SendNext(session.GetComponent<SessionVariables>().SpearCount);
        }
        else
        {
            session.GetComponent<SessionVariables>().NPCCount = (int)stream.ReceiveNext();
            session.GetComponent<SessionVariables>().HuntedCount = (int)stream.ReceiveNext();
            session.GetComponent<SessionVariables>().HunterCount = (int)stream.ReceiveNext();
            session.GetComponent<SessionVariables>().SpearCount = (int)stream.ReceiveNext();
        }
    }
}
