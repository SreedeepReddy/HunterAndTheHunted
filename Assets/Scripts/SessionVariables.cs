using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Photon.Pun;

public class SessionVariables : MonoBehaviour
{
    public bool gameStarted = false;
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

    private void StartGame() 
    {
        if (startGameInit) 
        {
            GameObject[] hunteds = GameObject.FindGameObjectsWithTag("Hunted");

            foreach (GameObject hunted in hunteds)
            {
                hunted.GetComponentInChildren<CharacterMovement>().speed = 200;
                hunted.transform.parent.Find("HUD").GetComponent<TimerCountDown>().gameStart = true;
            }

            GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

            foreach (GameObject npc in npcs)
            {
                npc.GetComponent<NavMeshAgent>().speed = 3;
            }

            GameObject hunter = GameObject.FindGameObjectWithTag("Hunter");

            hunter.GetComponentInChildren<CharacterMovement>().speed = 300;

            totalNonHunter = HuntedCount + NPCCount;
            hunter.transform.parent.Find("HUD").GetComponent<TimerCountDown>().gameStart = true;
            startGameInit = false;
        }
        
    }

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

        if (HuntedCount >= 2 && HunterCount == 1 && gameStarted == false) 
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
