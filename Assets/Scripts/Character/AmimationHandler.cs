using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmimationHandler : MonoBehaviour
{
    CharacterController cc;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded == true && cc.velocity.magnitude > 2f)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
