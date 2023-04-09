using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RenderLight : MonoBehaviourPunCallbacks
{
    void Update()
    {
        if (photonView.IsMine)
        {
            bool renderLight = photonView.gameObject.GetComponent<SetCharacter>().isHunter;
            GetComponent<Light>().enabled = renderLight;
        }
    }
}
