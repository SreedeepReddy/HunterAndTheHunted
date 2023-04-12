using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.GetComponent<Outline>().enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.GetComponent<Outline>().enabled = false;
    }
}
