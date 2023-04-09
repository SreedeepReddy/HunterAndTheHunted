using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitCharacter : MonoBehaviour
{
    public Material hunterRed;
    public Material huntedBlue;
    private void InitHunter()
    {
        this.AddComponent<Outline>();
        this.GetComponent<Outline>().outlineColor = Color.red;
        this.GetComponent<Outline>().outlineWidth = 10f;
        this.GetComponent<Outline>().enabled = false;

        GameObject light = transform.Find("XRCardboardRig/HeightOffset/Main Camera/Spot Light").gameObject;
        Light spotlight = light.GetComponent<Light>();
        spotlight.range = 20;
        spotlight.spotAngle = 179;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = hunterRed;

        this.GetComponent<CharacterMovement>().speed = 1500;
    }

    private void InitHunted()
    {
        this.AddComponent<Outline>();
        this.GetComponent<Outline>().outlineColor = Color.blue;
        this.GetComponent<Outline>().outlineWidth = 10f;
        this.GetComponent<Outline>().enabled = false;

        Renderer renderer = GetComponent<Renderer>();
        renderer.material = huntedBlue;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<SetCharacter>().isHunter) 
        {
            InitHunter();
        }

        if (this.GetComponent<SetCharacter>().isHunted)
        {
            InitHunted();
        }
    }
}
