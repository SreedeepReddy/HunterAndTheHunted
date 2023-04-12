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

    private void Start()
    {
        centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void Update()
    {
        if (Input.GetButtonDown("js10"))
        {
            Ray ray = myCamera.ScreenPointToRay(centerScreen);

            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.CompareTag("NPC"))
            {
                GameObject.Find("Session").GetComponent<SessionVariables>().NPCCount -= 1;
                GameObject.Find("Session").GetComponent<SessionVariables>().SpearCount -= 1;
                NPCKilled();
                Destroy(hitInfo.collider.gameObject);
            }

            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.CompareTag("Hunted"))
            {
                GameObject.Find("Session").GetComponent<SessionVariables>().HuntedCount -= 1;
                GameObject.Find("Session").GetComponent<SessionVariables>().SpearCount -= 1;
                PlayerKilled();
                GameObject hunted = hitInfo.collider.gameObject;
                Destroy(hunted.GetComponent<MeshFilter>().mesh);
                hunted.GetComponent<CapsuleCollider>().enabled = false;
                hunted.GetComponentInChildren<GameEnds>().OpenGameEndMenu();
            }
        }
    }
}