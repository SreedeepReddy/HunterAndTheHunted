using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherOrbs : MonoBehaviour
{
    private RaycastHit hitInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("js10"))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.name.Contains("Key"))
            {
                GameObject.Find("Session").GetComponent<SessionVariables>().OrbCollected += 1;
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }
}