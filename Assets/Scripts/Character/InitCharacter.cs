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
    public Material hunterMat;
    public PhotonView photonView;
    public GameObject SpotLight;
    public GameObject SMR_ref;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    public Mesh updatedMesh;

    private void InitHunter()
    {
        this.AddComponent<Outline>();
        this.GetComponent<HunterSpear>().enabled = true;
        this.GetComponent<Outline>().outlineColor = Color.red;
        this.GetComponent<Outline>().outlineWidth = 10f;
        this.GetComponent<Outline>().enabled = false;
        this.GetComponent<Animator>().enabled = true;
        skinnedMeshRenderer = SMR_ref.GetComponent<SkinnedMeshRenderer>();

        Light spotlight = SpotLight.GetComponent<Light>();
        spotlight.range = 20;
        spotlight.spotAngle = 179;
        HunterModel.SetActive(true);
        HunterHips.SetActive(true);
        Destroy(GetComponent<MeshFilter>().mesh);
        GameObject.Find("Session").GetComponent<SessionVariables>().HunterCount += 1;

        this.GetComponent<CharacterMovement>().speed = 300;

        spotlight.AddComponent<RenderLight>();

        photonView.RPC(nameof(SyncMaterial), RpcTarget.OthersBuffered, true);
        this.gameObject.tag = "Hunter";
        this.GetComponent<InitCharacter>().enabled = false;
    }

    private void InitHunted()
    {
        this.AddComponent<Outline>();
        this.GetComponent<Outline>().outlineColor = Color.blue;
        this.GetComponent<Outline>().outlineWidth = 10f;
        this.GetComponent<Outline>().enabled = false;
        GameObject.Find("Session").GetComponent<SessionVariables>().HuntedCount += 1;

        this.GetComponent<CharacterMovement>().speed = 200;

        Renderer renderer = GetComponent<Renderer>();
        renderer.material = huntedBlue;

        photonView.RPC(nameof(SyncMaterial), RpcTarget.OthersBuffered, false);
        this.gameObject.tag = "Hunted";
        this.GetComponent<InitCharacter>().enabled = false;
    }

    [PunRPC]
    private void SyncMaterial(bool isHunter)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (isHunter)
        {
            renderer.material = hunterMat;
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

        skinnedMeshRenderer.sharedMesh = updatedMesh;
        photonView.RPC("SyncMesh", RpcTarget.OthersBuffered, updatedMesh);
    }

    [PunRPC]
    void SyncMesh(Mesh mesh)
    {
        skinnedMeshRenderer.sharedMesh = mesh;
    }
}
