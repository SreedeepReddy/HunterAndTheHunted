using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetFirstSelectedOnEnableVR : MonoBehaviour
{
    public GameObject vrGroup;
    public GameObject firstSelected;
    public EventSystem eventSystem;

    // Update is called once per frame
    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            Debug.Log("Nothing Selected");
            invokeFirstSelected();
        }
    }

    private void invokeFirstSelected() 
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
        this.enabled = false;   
    }

}
