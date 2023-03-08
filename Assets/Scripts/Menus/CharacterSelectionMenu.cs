using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class CharacterSelectionMenu : MonoBehaviour
{
    public void Hunter()
    {
        PhotonNetwork.LoadLevel("Level");
    }

    public void Hunted()
    {
        PhotonNetwork.LoadLevel("Level");
    }
}
