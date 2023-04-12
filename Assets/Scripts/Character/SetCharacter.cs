using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacter : MonoBehaviour
{
    public bool isHunter = false;
    public bool isHunted = false;

    private void Start()
    {
        if (this.GetComponentInChildren<Camera>().enabled == false) 
        {
            this.GetComponentInChildren<Camera>().enabled = true;
        }
    }

}
