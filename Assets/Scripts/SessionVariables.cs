using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class SessionVariables : MonoBehaviour
{
    private bool prevGameStarted;
    private int prevOrbCollected;
    private int prevNPCCount;
    private int prevHuntedCount;
    private int prevHunterCount;
    private int prevSpearCount;
    private string prevGameEnd;
    private float prevSessionDuration;

    
    public PhotonView photonView;

    [PunRPC]
    void UpdateGameStarted(bool value)
    {
        if (prevGameStarted != value)
        {
            prevGameStarted = value;
            gameStarted = value;
            photonView.RPC("UpdateGameStartedRPC", RpcTarget.Others, value);
        }
    }

    [PunRPC]
    void UpdateGameStartedRPC(bool value)
    {
        prevGameStarted = value;
        gameStarted = value;
    }

    [PunRPC]
    void UpdateOrbCollected(int value)
    {
        if (prevOrbCollected != value)
        {
            prevOrbCollected = value;
            OrbCollected = value;
            photonView.RPC("UpdateOrbCollectedRPC", RpcTarget.Others, value);
        }
    }

    [PunRPC]
    void UpdateOrbCollectedRPC(int value)
    {
        prevOrbCollected = value;
        OrbCollected = value;
    }

    [PunRPC]
    void UpdateNPCCount(int value)
    {
        if (prevNPCCount != value)
        {
            prevNPCCount = value;
            NPCCount = value;
            photonView.RPC("UpdateNPCCountRPC", RpcTarget.Others, value);
        }
    }

    [PunRPC]
    void UpdateNPCCountRPC(int value)
    {
        prevNPCCount = value;
        NPCCount = value;
    }

    [PunRPC]
    void UpdateHuntedCount(int value)
    {
        if (prevHuntedCount != value)
        {
            prevHuntedCount = value;
            HuntedCount = value;
            photonView.RPC("UpdateHuntedCountRPC", RpcTarget.Others, value);
        }
    }

    [PunRPC]
    void UpdateHuntedCountRPC(int value)
    {
        prevHuntedCount = value;
        HuntedCount = value;
    }

    [PunRPC]
    void UpdateHunterCount(int value)
    {
        if (prevHunterCount != value)
        {
            prevHunterCount = value;
            HunterCount = value;
            photonView.RPC("UpdateHunterCountRPC", RpcTarget.Others, value);
        }
    }

    [PunRPC]
    void UpdateHunterCountRPC(int value)
    {
        prevHunterCount = value;
        HunterCount = value;
    }

    [PunRPC]
    void UpdateSpearCount(int value)
    {
        if (prevSpearCount != value)
        {
            prevSpearCount = value;
            SpearCount = value;
            photonView.RPC("UpdateSpearCountRPC", RpcTarget.Others, value);
        }
    }

    [PunRPC]
    void UpdateSpearCountRPC(int value)
    {
        prevSpearCount = value;
        SpearCount = value;
    }

    [PunRPC]
    void UpdateGameEnd(string value)
    {
        gameEnd = value;
    }

    [PunRPC]
    void UpdateSessionDuration(float value)
    {
        sessionDuration = value;
    }

    public bool gameStarted = false;
    [SerializeField]
    private bool startGameInit = true;
    private bool endGameInit = true;
    public int OrbCollected = 0;
    public int NPCCount = 0;
    //public int PlayerCount = 0;
    public int HuntedCount = 0;
    public int HunterCount = 0;
    public int SpearCount = 0;
    public string gameEnd = "Game Over";
    public float sessionDuration = 300f;
    public GameObject hunterPlayer;
    public int totalNonHunter;

    private void PauseGame()
    {
        GameObject[] hunteds = GameObject.FindGameObjectsWithTag("Hunted");

        foreach (GameObject hunted in hunteds)
        {
            hunted.GetComponentInChildren<CharacterMovement>().speed = 0;
        }

        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject npc in npcs)
        {
            npc.GetComponent<NavMeshAgent>().speed = 0;
        }

        GameObject hunter = GameObject.FindGameObjectWithTag("Hunter");

        hunter.GetComponentInChildren<CharacterMovement>().speed = 0;
    }

    //[PunRPC]
    private void StartGame() 
    {
        if (startGameInit) 
        {
            GameObject[] hunteds = GameObject.FindGameObjectsWithTag("Hunted");

            foreach (GameObject hunted in hunteds)
            {
                hunted.GetComponentInChildren<CharacterMovement>().speed = 200;
                //hunted.transform.parent.Find("HUD").GetComponent<TimerCountDown>().gameStart = true;
            }

            GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

            foreach (GameObject npc in npcs)
            {
                npc.GetComponent<NavMeshAgent>().speed = 3;
            }

            GameObject hunter = GameObject.FindGameObjectWithTag("Hunter");

            hunter.GetComponentInChildren<CharacterMovement>().speed = 300;

            totalNonHunter = HuntedCount + NPCCount;
            //hunter.transform.parent.Find("HUD").GetComponent<TimerCountDown>().gameStart = true;
            startGameInit = false;
        }
        
    }

    //[PunRPC]
    private void DisableHunterSelection() 
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject target in targets)
        {
            Button[] buttons = target.GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                if (button.gameObject.name == "Hunter")
                {
                    button.interactable = false;
                }
            }
        }
    }

    //[PunRPC]
    private void OpenEndScreen() 
    {
        GameObject[] hunteds = GameObject.FindGameObjectsWithTag("Hunted");

        if (gameEnd == "Hunted Win")
        {
            foreach (GameObject hunted in hunteds)
            {
                hunted.GetComponentInChildren<CharacterMovement>().speed = 0;
                hunted.GetComponentInChildren<GameEnds>().OpenGameEndMenu();
                hunted.GetComponentInChildren<GameEnds>().gamestatetxt = gameEnd;
            }
        }

        GameObject hunter = GameObject.FindGameObjectWithTag("Hunter");

        hunter.GetComponentInChildren<CharacterMovement>().speed = 0;
        hunter.GetComponentInChildren<GameEnds>().OpenGameEndMenu();
        hunter.GetComponentInChildren<GameEnds>().gamestatetxt = gameEnd;

        /*
        Text gameEnds = FindObjectOfType<Text>().text == "Game Over" ? FindObjectOfType<Text>() : null;

        if (gameEnds != null)
        {
            gameEnds.text = gameEnd;
        }
        */
        this.enabled = false;

    }

    private void Update()
    {
        /*
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("UpdateGameStarted", RpcTarget.All, gameStarted);
            photonView.RPC("UpdateOrbCollected", RpcTarget.All, OrbCollected);
            photonView.RPC("UpdateNPCCount", RpcTarget.All, NPCCount);
            photonView.RPC("UpdateHuntedCount", RpcTarget.All, HuntedCount);
            photonView.RPC("UpdateHunterCount", RpcTarget.All, HunterCount);
            photonView.RPC("UpdateSpearCount", RpcTarget.All, SpearCount);
            photonView.RPC("UpdateGameEnd", RpcTarget.All, gameEnd);
            photonView.RPC("UpdateSessionDuration", RpcTarget.All, sessionDuration);
        }
        */
        if (!gameStarted)
        {
            PauseGame();
        }
        else 
        {
            if (sessionDuration > 0f)
            {
                sessionDuration -= Time.deltaTime;
                // Update UI
            }
            else
            {
                gameEnd = "Hunted Win";
                Debug.Log("Hunted Win");
                OpenEndScreen();
            }
        }

        if (HuntedCount >= 2 && HunterCount == 1) 
        {
            gameStarted = true;
            StartGame();
        }

        if (gameStarted && HuntedCount == 0) 
        {
            gameEnd = "Hunter Wins";
            Debug.Log("Hunter Wins");
            OpenEndScreen();
        }

        if (gameStarted && totalNonHunter - (HuntedCount + NPCCount) > 6) 
        {
            gameEnd = "Hunted Win";
            Debug.Log("Hunted Win");
            OpenEndScreen();
        }

        if (HunterCount == 1) 
        {
            DisableHunterSelection();
        }

        if (OrbCollected == 10) 
        {
            gameEnd = "Hunted Win";
            Debug.Log("Hunted Win");
            OpenEndScreen();
        }
    }

    
}
