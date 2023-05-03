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
    public int NPCCount = 5;
    //public int PlayerCount = 0;
    public int HuntedCount = 0;
    public int HunterCount = 0;
    public int SpearCount = 3;
    public string gameEnd = "Game Over!";
    public float sessionDuration = 300f;

    private void PauseGame()
    {
        GameObject[] hunteds = GameObject.FindGameObjectsWithTag("Hunted");

        foreach (GameObject hunted in hunteds)
        {
            hunted.GetComponent<CharacterMovement>().speed = 0;
        }

        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject npc in npcs)
        {
            npc.GetComponent<NavMeshAgent>().speed = 0;
        }

        GameObject hunter = GameObject.FindGameObjectWithTag("Hunter");

        hunter.GetComponent<CharacterMovement>().speed = 0;
    }

    private void StartGame() 
    {
        if (startGameInit) 
        {
            GameObject[] hunteds = GameObject.FindGameObjectsWithTag("Hunted");

            foreach (GameObject hunted in hunteds)
            {
                hunted.GetComponent<CharacterMovement>().speed = 200;
            }

            GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

            foreach (GameObject npc in npcs)
            {
                npc.GetComponent<NavMeshAgent>().speed = 3;
            }

            GameObject hunter = GameObject.FindGameObjectWithTag("Hunter");

            hunter.GetComponent<CharacterMovement>().speed = 300;
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
        if (endGameInit) 
        {
            GameObject[] hunteds = GameObject.FindGameObjectsWithTag("Hunted");

            if (gameEnd == "Hunted Wins!") 
            {
                foreach (GameObject hunted in hunteds)
                {
                    hunted.GetComponent<CharacterMovement>().speed = 0;
                    hunted.GetComponentInChildren<GameEnds>().OpenGameEndMenu();
                }
            }
            
            GameObject hunter = GameObject.FindGameObjectWithTag("Hunter");

            hunter.GetComponent<CharacterMovement>().speed = 0;
            hunter.GetComponentInChildren<GameEnds>().OpenGameEndMenu();

            Text gameEnds = FindObjectOfType<Text>().text == "Game Over!" ? FindObjectOfType<Text>() : null;

            if (gameEnds != null)
            {
                gameEnds.text = gameEnd;
            }
            endGameInit = false;
        }
        
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
                gameEnd = "Hunted Wins!";
                Debug.Log("Hunted Wins!");
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
            gameEnd = "Hunter Wins!";
            Debug.Log("Hunter Wins!");
            OpenEndScreen();
        }

        if (gameStarted && SpearCount == 0) 
        {
            gameEnd = "Hunted Wins!";
            Debug.Log("Hunted Wins!");
            OpenEndScreen();
        }

        if (HunterCount == 1) 
        {
            DisableHunterSelection();
        }

        if (OrbCollected == 5) 
        {
            gameEnd = "Hunted Wins!";
            Debug.Log("Hunted Wins!");
            OpenEndScreen();
        }
    }

    
}
