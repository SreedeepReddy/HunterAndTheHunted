using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterMovement : MonoBehaviour
{
    public GameObject cameraObj;
    public bool joyStickMode;
    public float speed = 20f;

    public CharacterController charCntrl;
    public PhotonView view;

    private Quaternion Crotation = Quaternion.identity;

    void Start()
    {
        charCntrl = GetComponent<CharacterController>();
        view = GetComponent<PhotonView>();
        if (view.IsMine == false) 
        {
            cameraObj.SetActive(false);
        }
    }

    void Update()
    {
        if (view.IsMine)
        {
            //Get horizontal and Vertical movements
            float horComp = Input.GetAxis("Horizontal");
            float vertComp = Input.GetAxis("Vertical");

            if (joyStickMode)
            {
                vertComp = Input.GetAxis("Vertical");
                horComp = Input.GetAxis("Horizontal") * 1;
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

    private void LateUpdate()
    {
        Crotation.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, cameraObj.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = Crotation;
    }
}