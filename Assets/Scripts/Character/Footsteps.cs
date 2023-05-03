using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Footsteps : MonoBehaviour
{
    CharacterController cc;

    // faudio[0] - Footsteps
    // faudio[1] - Orb Collection
    private AudioSource[] faudio;

    [SerializeField] bool isNpc;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        faudio = GetComponents<AudioSource>();
        if (isNpc)
            agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNpc)
        {
            if (agent.velocity.magnitude > 2f && faudio[0].isPlaying == false)
            {
                faudio[0].volume = Random.Range(0.8f, 1);
                faudio[0].pitch = Random.Range(0.8f, 1.1f);
                faudio[0].Play();
            }
        }
        else
        {
            if (cc.isGrounded == true && cc.velocity.magnitude > 2f && faudio[0].isPlaying == false)
            {
                faudio[0].volume = Random.Range(0.8f, 1);
                faudio[0].pitch = Random.Range(0.8f, 1.1f);
                faudio[0].Play();
            }
        }
        
    }
}
