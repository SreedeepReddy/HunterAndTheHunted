using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenCharacterMenu : MonoBehaviour
{
    public GameObject character;
    public GameObject reticle;
    public EventSystem eventSystem;
    public GameObject firstSelected;
    public GameObject vrGroup;
    public GameObject charMenu;
    private bool initCharMenu = true;

    private void InitCharMenu()
    {
        charMenu.SetActive(true);
        character.GetComponent<CharacterMovement>().speed = 0;
        reticle.SetActive(false);
        eventSystem.GetComponent<XRCardboardInputModule>().enabled = false;
        eventSystem.GetComponent<StandaloneInputModule>().enabled = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
        initCharMenu = false;
    }

    private void Update()
    {
        if (vrGroup.activeSelf && initCharMenu) 
        {
            InitCharMenu();
        }
    }

}