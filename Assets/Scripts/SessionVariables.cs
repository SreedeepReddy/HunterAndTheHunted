using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionVariables : MonoBehaviour
{
    public bool gameStarted = false;
    private bool startGameInit = true;
    private bool endGameInit = true;
    public int NPCCount = 5;
    //public int PlayerCount = 0;
    public int HuntedCount = 0;
    public int HunterCount = 0;
    public int SpearCount = 3;
    private string gameEnd = "Game Over!";

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
            npc.GetComponent<NPCMovementScript>().moveSpeed = 0;
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
                hunted.GetComponent<CharacterMovement>().speed = 1000;
            }

            GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

            foreach (GameObject npc in npcs)
            {
                npc.GetComponent<NPCMovementScript>().moveSpeed = 1000;
            }

            GameObject hunter = GameObject.FindGameObjectWithTag("Hunter");

            hunter.GetComponent<CharacterMovement>().speed = 1500;
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

        if (HuntedCount >= 1 && HunterCount == 1) 
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
    }
}
