using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    public bool cookJump = false;

    public bool glide = false;

    public bool jump = false;

    public bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            cookJump = true;
            crouch = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            cookJump = false;
            jump = true;
            crouch = false;
        }
        if (Input.GetButtonDown("Glide"))
        {
            glide = true;
        }
        if(Input.GetButtonUp("Glide"))
        {
            glide = false;
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log(jump);
        controller.Move(horizontalMove* Time.fixedDeltaTime, crouch, cookJump, jump, glide);
        jump = false;
        
    }
}
