using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public float countDown;
    public bool gameStart = false;
    public Text countD;
    void Start() 
    {
        countDown = GameObject.Find("Session").gameObject.GetComponent<SessionVariables>().sessionDuration;
    }

    // Update is called once per frame
    void Update()
    {
        //if (this.transform.parent.parent.gameObject.GetComponentInChildren<CharacterMovement>().speed != 0) 
        if (GameObject.Find("Session").GetComponent<SessionVariables>().gameStarted)
        {
            gameStart = true;
        }
        if (gameStart) 
        {
            countDown -= Time.deltaTime;
        }

        int ctd = (int)countDown;

        countD.text = ctd.ToString();      
    }
}
