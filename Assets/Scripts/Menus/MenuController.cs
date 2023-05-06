using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class MenuController : MonoBehaviour
{
    public GameObject firstSelected;
    public GameObject reticle;
    public EventSystem eventSystem;
    public GameObject VRGroup;

    private bool menuControlled = false;
    // Start is called before the first frame update
    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
    void MenuControl()
    {
        EventSystem.current.SetSelectedGameObject(null);
        reticle.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        //eventSystem.GetComponent<XRCardboardInputModule>().enabled = false;
        eventSystem.GetComponent<StandaloneInputModule>().enabled = true;
        //EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    private void Update()
    {
        if (!menuControlled) 
        {
            if (VRGroup.activeSelf)
            {
                EventSystem.current.SetSelectedGameObject(null);
                MenuControl();
                menuControlled = true;
            }
            else 
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }
}
