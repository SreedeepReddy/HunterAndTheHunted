using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class SpawnNPC : MonoBehaviour
{
    public GameObject npc;
    public int npcAmt = 3;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;
    public float startDelay = 2.0f;

    private void Start()
    {
        GameObject session = GameObject.Find("Session");
        // Call the SpawnPlayer method with a delay of 2 seconds
        while (session.GetComponent<SessionVariables>().NPCCount < npcAmt)
        {
            Invoke("SpawnNPCs", startDelay);
            session.GetComponent<SessionVariables>().NPCCount++;
        }
        
    }

    private void SpawnNPCs()
    {
        // Check if the current scene is "Level"
        if (SceneManager.GetActiveScene().name == "Level")
        {
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY), UnityEngine.Random.Range(minZ, maxZ));
            PhotonNetwork.Instantiate(npc.name, randomPosition, Quaternion.identity);
        }
    }
}