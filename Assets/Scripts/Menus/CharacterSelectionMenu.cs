using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.EventSystems;

public class CharacterSelectionMenu : MonoBehaviour
{
    public GameObject character;
    public GameObject firstSelected;
    public GameObject characterSelectionCanvas;
    public GameObject reticle;
    public EventSystem eventSystem;
    public GameObject XRRig;

    public void Awake() 
    {
        XRRig.GetComponent<XRCardboardController>().EnableVRCoroutine();
    }

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void Hunter()
    {
        character.GetComponent<SetCharacter>().isHunter = true;

        eventSystem.GetComponent<StandaloneInputModule>().enabled = false;
        eventSystem.GetComponent<XRCardboardInputModule>().enabled = true;
        character.GetComponent<CharacterMovement>().speed = 1500;
        reticle.SetActive(true);

        characterSelectionCanvas.SetActive(false);      
    }

    public void Hunted()
    {
        character.GetComponent<SetCharacter>().isHunted = true;

        eventSystem.GetComponent<StandaloneInputModule>().enabled = false;
        eventSystem.GetComponent<XRCardboardInputModule>().enabled = true;
        character.GetComponent<CharacterMovement>().speed = 1000;
        reticle.SetActive(true);

        characterSelectionCanvas.SetActive(false);
    }
}
