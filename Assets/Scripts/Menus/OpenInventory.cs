using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventoryCanvas;
    public GameObject character;
    public GameObject firstSelected;
    public GameObject reticle;
    public EventSystem eventSystem;
    public GameObject settingsCanvas;

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
        
        inventoryCanvas.SetActive(false);
        reticle.SetActive(true);
    }

    public void OpenInventoryMenu()
    {
        settingsCanvas.SetActive(false);
        inventoryCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
    void Update()
    {

    }
}
