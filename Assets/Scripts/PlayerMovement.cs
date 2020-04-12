﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 25f;
    private float horizontalMove = 0f;
    
    private bool jumpFlag = false;
    private bool jump = false;

    public bool hasSpeedPotion = false;
    public bool hasJumpPotion = false;
    public float modAmount = 0f;
    private float potionTimeMax = 10f;
    private float potionTime = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (jumpFlag)
        {
            jumpFlag = false;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

    }

    public void OnLanding()
    {
        jump = false;
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        if (hasJumpPotion && potionTime < potionTimeMax)
        {
            controller.m_JumpForceMod = modAmount;
            potionTime += Time.fixedDeltaTime;
        }
        else
        {
            potionTime = 0f;
            controller.m_JumpForceMod = 0f;
            hasJumpPotion = false;
        }


        if (jump)
        {
            jumpFlag = true;
        }
    }
}
