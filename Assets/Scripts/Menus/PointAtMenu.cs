using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PointAtMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject character;
    public float distanceFromCanvas = 20f;

    private Vector3 cameraOffset = new Vector3(0f, 0f, -10f);
    private Vector3 canvasCenter;
    private Camera mainCamera;

    void Start()
    {
        Transform cameraTransform = character.transform.Find("XRCardboardRig/HeightOffset/Main Camera");
        mainCamera = cameraTransform.GetComponent<Camera>();

        canvasCenter = canvas.transform.position;

        // Rotate the canvas to face the camera at the beginning of the scene
        Vector3 cameraDirection = mainCamera.transform.position - canvasCenter;
        canvas.transform.rotation = Quaternion.LookRotation(cameraDirection);
    }

    void Update()
    {
        // Position the camera at the center of the canvas
        transform.position = canvasCenter + cameraOffset;

        // Move the character to make sure the canvas is in its viewing range
        Vector3 characterPosition = canvasCenter - mainCamera.transform.forward * distanceFromCanvas;
        character.transform.position = characterPosition;

        // Scale the canvas to fill the screen
        float distance = Vector3.Distance(mainCamera.transform.position, canvas.transform.position);
        float canvasScale = distance * Mathf.Tan(mainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad) * 2f;

        canvas.transform.localScale = new Vector3(canvasScale, canvasScale, 1f);
    }
}
