using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;

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
        Invoke("SpawnPlayer", startDelay);
    }

    private void SpawnPlayer()
    {
        // Check if the current scene is "Level"
        if (SceneManager.GetActiveScene().name == "Level")
        {
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY), UnityEngine.Random.Range(minZ, maxZ));
            PhotonNetwork.Instantiate(player.name, randomPosition, Quaternion.identity);
        }
    }
}
