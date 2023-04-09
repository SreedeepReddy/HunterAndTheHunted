using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    CharacterController cc;
    AudioSource faudio;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        faudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cc.isGrounded == true && cc.velocity.magnitude > 2f && faudio.isPlaying == false)
        {
            faudio.volume = Random.Range(0.8f, 1);
            faudio.pitch = Random.Range(0.8f, 1.1f);
            faudio.Play();
        }
    }
}
