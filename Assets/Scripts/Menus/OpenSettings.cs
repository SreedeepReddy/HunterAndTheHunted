using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenSettings : MonoBehaviour
{
    public GameObject settingsCanvas;
    public GameObject character;
    public GameObject firstSelected;
    public GameObject reticle;
    public EventSystem eventSystem;

    public void Resume() 
    {
        eventSystem.GetComponent<StandaloneInputModule>().enabled = false;
        eventSystem.GetComponent<XRCardboardInputModule>().enabled = true;
        if (character.GetComponent<SetCharacter>().isHunter)
        {
            character.GetComponent<CharacterMovement>().speed = 300;
        }
        else 
        {
            character.GetComponent<CharacterMovement>().speed = 200;
        }
        settingsCanvas.SetActive(false);
        reticle.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OpenSettingsMenu() 
    {
        character.GetComponent<CharacterMovement>().speed = 0;
        reticle.SetActive(false);
        eventSystem.GetComponent<XRCardboardInputModule>().enabled = false;
        eventSystem.GetComponent<StandaloneInputModule>().enabled = true;
        settingsCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
    void Update()
    {
        if (Input.GetButtonDown("js7")) 
        {
            OpenSettingsMenu();
        }
    }
}
