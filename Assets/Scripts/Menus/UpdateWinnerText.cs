using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWinnerText : MonoBehaviour
{
    public string winner;
    private void Start()
    {
        winner = GameObject.Find("Session").GetComponent<SessionVariables>().gameEnd;
    }
    void Update()
    {
        winner = GameObject.Find("Session").GetComponent<SessionVariables>().gameEnd;
        Debug.Log(winner);  
        FindObjectOfType<Text>().text = winner;
    }
}
