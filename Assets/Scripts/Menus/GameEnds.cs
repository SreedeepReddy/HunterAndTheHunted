using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameEnds : MonoBehaviour
{
    public GameObject gameEndScreen;
    public GameObject character;
    public GameObject firstSelected;
    public GameObject reticle;
    public EventSystem eventSystem;

    public void MainMenu()
    {
        PhotonNetwork.LeaveRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenGameEndMenu()
    {
        character.GetComponent<CharacterMovement>().speed = 0;
        reticle.SetActive(false);
        eventSystem.GetComponent<XRCardboardInputModule>().enabled = false;
        eventSystem.GetComponent<StandaloneInputModule>().enabled = true;
        gameEndScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}
