using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    CharacterController cc;

    // faudio[0] - Footsteps
    // faudio[1] - Orb Collection
    private AudioSource[] faudio;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        faudio = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cc.isGrounded == true && cc.velocity.magnitude > 2f && faudio[0].isPlaying == false)
        {
            faudio[0].volume = Random.Range(0.8f, 1);
            faudio[0].pitch = Random.Range(0.8f, 1.1f);
            faudio[0].Play();
        }
    }
}
