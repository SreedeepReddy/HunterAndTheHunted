using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterSpear : MonoBehaviour
{
    public Camera myCamera;

    private RaycastHit hitInfo;
    private Vector2 centerScreen;

    public GameObject killedPlayer;
    public GameObject killedNPC;

    private LineRenderer lineRenderer;

    private void Start() 
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.enabled = false;

        centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void PlayerKilled()
    {
        StartCoroutine(DisplayPlayerKilled());
    }
    IEnumerator DisplayPlayerKilled()
    {
        killedPlayer.SetActive(true);
        yield return new WaitForSeconds(2);
        killedPlayer.SetActive(false);
    }

    private void NPCKilled()
    {
        StartCoroutine(DisplayNPCKilled());
    }
    IEnumerator DisplayNPCKilled()
    {
        killedNPC.SetActive(true);
        yield return new WaitForSeconds(2);
        killedNPC.SetActive(false);
    }
    private IEnumerator FadeLineRenderer()
    {
        Color startColor = new Color(0.4f, 0.2f, 0f); // Dark Brown
        Color endColor = new Color(0.2f, 0.1f, 0f);
        float elapsedTime = 0f;
        float fadeTime = 0.4f; // Adjust fade time as needed

        // Store the original material color
        Color originalStartColor = lineRenderer.material.GetColor("_Color");

        // Set the start color
        lineRenderer.material.SetColor("_Color", startColor);

        while (elapsedTime < fadeTime)
        {
            float t = elapsedTime / fadeTime;
            Color lerpedColor = Color.Lerp(startColor, endColor, t);

            // Set the color for both start and end points
            lineRenderer.material.SetColor("_Color", lerpedColor);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Restore the original material color
        lineRenderer.material.SetColor("_Color", originalStartColor);

        lineRenderer.enabled = false;
    }


    private void Update()
    {
        if (Input.GetButtonDown("js10") && GameObject.Find("Session").GetComponent<SessionVariables>().SpearCount > 0)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.CompareTag("NPC"))
            {
                GameObject.Find("Session").GetComponent<SessionVariables>().NPCCount -= 1;
                GameObject.Find("Session").GetComponent<SessionVariables>().SpearCount -= 1;

                // Enable and set positions for the line renderer
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hitInfo.point);

                // Start fading coroutine
                StartCoroutine(FadeLineRenderer());

                NPCKilled();
                Destroy(hitInfo.collider.gameObject);
            }

            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.CompareTag("Hunted"))
            {
                GameObject.Find("Session").GetComponent<SessionVariables>().HuntedCount -= 1;
                GameObject.Find("Session").GetComponent<SessionVariables>().SpearCount -= 1;
                PlayerKilled();

                // Enable and set positions for the line renderer
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hitInfo.point);

                // Start fading coroutine
                StartCoroutine(FadeLineRenderer());

                GameObject hunted = hitInfo.collider.gameObject;
                Destroy(hunted.GetComponent<MeshFilter>().mesh);
                hunted.GetComponent<CapsuleCollider>().enabled = false;
                hunted.transform.parent.gameObject.GetComponentInChildren<GameEnds>().OpenGameEndMenu();
            }
        }
    }
}