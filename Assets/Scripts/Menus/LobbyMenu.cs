using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LobbyMenu : MonoBehaviourPunCallbacks
{
    public InputField createRoomCode;
    public InputField joinRoomCode;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomCode.text);
        PhotonNetwork.LoadLevel("Level");
        // LobbyMenuManager.OpenMenu(LobbyMenus.CharacterSelectionMenu, gameObject);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomCode.text);
        PhotonNetwork.LoadLevel("Level");
        // LobbyMenuManager.OpenMenu(LobbyMenus.CharacterSelectionMenu, gameObject);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*public override void OnJoinedRoom()
    {
        
    }*/
}
