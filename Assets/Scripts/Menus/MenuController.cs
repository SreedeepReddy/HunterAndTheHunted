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
    // Start is called before the first frame update
    void Start()
    {
        reticle.SetActive(false);
        eventSystem.GetComponent<XRCardboardInputModule>().enabled = false;
        eventSystem.GetComponent<StandaloneInputModule>().enabled = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}
