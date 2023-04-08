using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenCharacterMenu : MonoBehaviour
{
    public GameObject character;
    public GameObject reticle;
    public EventSystem eventSystem;
    public GameObject firstSelected;

    private void Start()
    {
        character.GetComponent<CharacterMovement>().speed = 0;
        reticle.SetActive(false);
        eventSystem.GetComponent<XRCardboardInputModule>().enabled = false;
        eventSystem.GetComponent<StandaloneInputModule>().enabled = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}