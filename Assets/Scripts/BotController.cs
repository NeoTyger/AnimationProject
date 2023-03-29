using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotController : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("state",1); // Walk
        }
        
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetInteger("state",2); // Run
        }
        
        else if (Input.GetKey(KeyCode.Space))
        { 
            animator.SetInteger("state",3); // Jump
        }

        else if(Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("state",-1); // Turn left
        }
        
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("state",-2); // Turn right
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("state",-3); // Turn
        }
        else
        {
            animator.SetInteger("state", 0); // Idle
        }
    }
}
