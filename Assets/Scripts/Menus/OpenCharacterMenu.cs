using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCharacterMenu : MonoBehaviour
{
    public GameObject characterSelectionMenu;
    public GameObject character;
    private bool triggerMenu = false;


    void CharacterMenu()
    {
        characterSelectionMenu.SetActive(true);
        characterSelectionMenu.transform.Find("CharacterSelectionMenu").GetComponent<CharacterSelectionMenu>().character = character;
        triggerMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Character(Clone)")) 
        {
            if (!GameObject.Find("Character(Clone)").gameObject.GetComponent<SetCharacter>().isHunted && !GameObject.Find("Character(Clone)").gameObject.GetComponent<SetCharacter>().isHunter)
            {
                character = GameObject.Find("Character(Clone)");
                triggerMenu = true;
            }
        }        

        if (triggerMenu) 
        {
            CharacterMenu();
        }
    }
}
