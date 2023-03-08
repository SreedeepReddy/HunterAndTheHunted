using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LobbyMenuManager
{
    public static GameObject lobbyMenu, characterSelection;

    public static bool IsInitialized { get; private set; }

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        lobbyMenu = canvas.transform.Find("LobbyMenu").gameObject;
        characterSelection = canvas.transform.Find("CharacterSelectionMenu").gameObject;
        IsInitialized = true;
    }

    public static void OpenMenu(LobbyMenus menu, GameObject callingMenu)
    {
        if (!IsInitialized)
        {
            Init();
        }
        switch(menu)
        {
            case LobbyMenus.LobbyMenu:
                lobbyMenu.SetActive(true);
                break;
            case LobbyMenus.CharacterSelectionMenu:
                characterSelection.SetActive(true);
                break;
        }
        callingMenu.SetActive(false);
    }


}
