using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOutline : MonoBehaviour
{
    public float raycastDistance = 10f;
    public LayerMask interactableLayer;
    private GameObject lastInteractableObject;
    private Outline outline;

    //private LineRenderer lineRenderer;
    //public Color raycastColor = Color.red;

    public GameObject Pointer;

    private void Start()
    {
        /*
        // Create and configure the Line Renderer component
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = raycastColor;
        lineRenderer.endColor = raycastColor;
        */
    }

    private void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        // Cast a ray from the center of the screen
        
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hitInfo;

        //lineRenderer.SetPosition(0, ray.origin);
        //lineRenderer.SetPosition(1, ray.origin + ray.direction * raycastDistance);


        if (Physics.Raycast(ray, out hitInfo, raycastDistance, interactableLayer))
        {
            Debug.Log("Raycast Hitting" + hitInfo.collider.gameObject);
            // Check if we hit a new object
            if (hitInfo.collider.gameObject != lastInteractableObject)
            {
                // Disable outline on the old object if it exists
                if (lastInteractableObject != null)
                {
                    DisableOutline(lastInteractableObject);
                }

                // Enable outline on the new object
                EnableOutline(hitInfo.collider.gameObject);
                lastInteractableObject = hitInfo.collider.gameObject;
            }
        }
        else
        {
            // Disable outline on the old object if it exists
            if (lastInteractableObject != null)
            {
                DisableOutline(lastInteractableObject);
                lastInteractableObject = null;
            }
        }

        void EnableOutline(GameObject obj)
        {
            Debug.Log(obj.name);
            outline = obj.GetComponent<Outline>();
            if (outline != null) 
            {
                outline.enabled = true;
                outline.OutlineMode = Outline.Mode.OutlineVisible;
            }  
        }

        void DisableOutline(GameObject obj)
        {
            if (outline != null)
            {
                outline.enabled = false;
            }
        }
    }
}
