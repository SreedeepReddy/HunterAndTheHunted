using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterMovement : MonoBehaviour
{
    public GameObject cameraObj;
    public bool joyStickMode;
    public float speed = 5f;

    public CharacterController charCntrl;
    public PhotonView view;

    void Start()
    {
        charCntrl = GetComponent<CharacterController>();
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            float horComp = Input.GetAxis("Horizontal");
            float vertComp = Input.GetAxis("Vertical");

            if (joyStickMode)
            {
                horComp = Input.GetAxis("Vertical");
                vertComp = -Input.GetAxis("Horizontal");
            }

            Vector3 moveVect = Vector3.zero;

            Vector3 cameraLook = cameraObj.transform.forward;
            cameraLook.y = 0f;
            cameraLook = cameraLook.normalized;

            Vector3 forwardVect = cameraLook;
            Vector3 rightVect = Vector3.Cross(forwardVect, Vector3.up).normalized * -1;

            moveVect = rightVect * horComp + forwardVect * vertComp;

            moveVect *= speed * Time.deltaTime;

            charCntrl.SimpleMove(moveVect);
        }
    }
}