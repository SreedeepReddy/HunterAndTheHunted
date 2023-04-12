using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitCharacter : MonoBehaviour
{
    public GameObject HunterModel;
    public GameObject HunterHips;
    public Material huntedBlue;
    public PhotonView photonView;
    public GameObject spotLight;
    private void InitHunter()
    {
        this.AddComponent<Outline>();
        this.GetComponent<Outline>().outlineColor = Color.red;
        this.GetComponent<Outline>().outlineWidth = 10f;
        this.GetComponent<Outline>().enabled = false;

        GameObject light = transform.Find("XRCardboardRig/HeightOffset/Main Camera/Spot Light").gameObject;
        Light spotlight = light.GetComponent<Light>();
        spotlight.range = 20;
        spotlight.spotAngle = 179;
        HunterModel.SetActive(true);
        HunterHips.SetActive(true);
        Destroy(GetComponent<MeshFilter>().mesh);


        this.GetComponent<CharacterMovement>().speed = 1500;

        spotLight.AddComponent<RenderLight>();

        photonView.RPC(nameof(SyncMaterial), RpcTarget.OthersBuffered, true);
    }

    private void InitHunted()
    {
        this.AddComponent<Outline>();
        this.GetComponent<Outline>().outlineColor = Color.blue;
        this.GetComponent<Outline>().outlineWidth = 10f;
        this.GetComponent<Outline>().enabled = false;

        Renderer renderer = GetComponent<Renderer>();
        renderer.material = huntedBlue;

        photonView.RPC(nameof(SyncMaterial), RpcTarget.OthersBuffered, false);
    }

    [PunRPC]
    private void SyncMaterial(bool isHunter)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (isHunter)
        {
            //renderer.material = hunterRed;
        }
        else
        {
            renderer.material = huntedBlue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<SetCharacter>().isHunter) 
        {
            InitHunter();
        }

        if (this.GetComponent<SetCharacter>().isHunted)
        {
            InitHunted();
        }
    }
}
