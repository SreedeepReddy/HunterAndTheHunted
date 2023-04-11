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
        StartCoroutine(CheckOutlineExists());
    }

    IEnumerator CheckOutlineExists()
    {
        while (outline == null)
        {
            outline = GetComponent<Outline>();
            yield return null;
        }

        outline.OutlineMode = Outline.Mode.OutlineVisible;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}
