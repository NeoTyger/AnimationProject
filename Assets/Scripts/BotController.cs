using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotController : MonoBehaviour
{

    private Animator animator;
    public float speed = 10f;
    public float jumpForce = 5f;
    private bool onGround = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetInteger("state",1);
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetInteger("state",2);
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("state",-1);
            
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("state",-1);
            
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("state",-1);
            
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            onGround = false;
            
            animator.SetInteger("state",3);
            
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        else
        {
            animator.SetInteger("state",0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
