using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacter : MonoBehaviour
{
    //public bool isHunter = false;
    //public bool isHunted = false;

    [SerializeField]
    private bool _isHunter = false;
    private PhotonView photonView;

    public bool isHunter
    {
        get { return _isHunter; }
        set
        {
            _isHunter = value;
            photonView.RPC("SetIsHunter", RpcTarget.OthersBuffered, _isHunter);
        }
    }

    [SerializeField]
    private bool _isHunted = false;
    public bool isHunted
    {
        get { return _isHunted; }
        set
        {
            _isHunted = value;
            photonView.RPC("SetIsHunted", RpcTarget.OthersBuffered, _isHunted);
        }
    }

    [PunRPC]
    void SetIsHunter(bool value)
    {
        _isHunter = value;
    }

    [PunRPC]
    void SetIsHunted(bool value)
    {
        _isHunted = value;
    }

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (this.GetComponentInChildren<Camera>().enabled == false) 
        {
            this.GetComponentInChildren<Camera>().enabled = true;
        }
    }

}
