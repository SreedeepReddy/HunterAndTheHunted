using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class CharacterSelectionMenu : MonoBehaviour
{
    public GameObject character;
    public void Hunter()
    {
        character.GetComponent<SetCharacter>().isHunter = true;
        GameObject.Find("CharacterSelectionCanvas").gameObject.SetActive(false);
        
    }

    public void Hunted()
    {
        character.GetComponent<SetCharacter>().isHunted = true;
        GameObject.Find("CharacterSelectionCanvas").gameObject.SetActive(false);
    }
}
