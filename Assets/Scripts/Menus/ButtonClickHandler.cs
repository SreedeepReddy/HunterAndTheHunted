using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    void Update()
    {
        if (button.gameObject == EventSystem.current.currentSelectedGameObject && Input.GetButtonDown("js5"))
        {
            InvokeButton();
        }
    }

    private void InvokeButton()
    {
        button.onClick.Invoke();
    }
}
