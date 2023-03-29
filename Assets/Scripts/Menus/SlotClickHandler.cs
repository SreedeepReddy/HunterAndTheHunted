using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class SlotClickHandler : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject character;
    public GameObject inventoryCanvas;
    public GameObject reticle;

    private Button slot;
    private void Awake()
    {
        slot = GetComponent<Button>();
    }
    void Update()
    {
        if (slot.gameObject == EventSystem.current.currentSelectedGameObject && Input.GetButtonDown("js5"))
        {
            InvokeButton();
        }
    }

    private void InvokeButton()
    {
        eventSystem.GetComponent<StandaloneInputModule>().enabled = false;
        eventSystem.GetComponent<XRCardboardInputModule>().enabled = true;
        character.GetComponent<CharacterMovement>().speed = 1000;
        inventoryCanvas.SetActive(false);
        reticle.SetActive(true);
        slot.onClick.Invoke();
    }
}
