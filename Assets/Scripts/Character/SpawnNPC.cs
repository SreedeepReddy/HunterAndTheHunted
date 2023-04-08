using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class SpawnNPC : MonoBehaviour
{
    public GameObject npc;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;
    public float startDelay = 2.0f;

    private void Start()
    {
        // Call the SpawnPlayer method with a delay of 2 seconds
        Invoke("SpawnNPCs", startDelay);
        Invoke("SpawnNPCs", startDelay);
        Invoke("SpawnNPCs", startDelay);
        Invoke("SpawnNPCs", startDelay);
        Invoke("SpawnNPCs", startDelay);
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