using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    public Camera mainCamera;
    private void Update()
    {
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f;
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);

        transform.rotation = targetRotation;
    }
}
