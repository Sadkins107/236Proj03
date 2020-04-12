using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 25f;
    private float horizontalMove = 0f;

    public AudioClip jumpClip;
    private bool jumpFlag = false;
    private bool jump = false;

    private bool attack = false;
    private bool attackFlag = false;

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

        if (attackFlag)
        {
            attackFlag = false;
            animator.SetBool("IsAttacking", true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (!animator.GetBool("IsJumping"))
            {
                AudioSource.PlayClipAtPoint(jumpClip, transform.position);
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }

        if (Input.GetButtonDown("Submit"))
        {
            if (!animator.GetBool("IsAttacking"))
            {
                attack = true;
                animator.SetBool("IsAttacking", true);
            }
        }

        if (Input.GetButtonUp("Submit"))
        {
            if (animator.GetBool("IsAttacking"))
            {
                attack = false;
                animator.SetBool("IsAttacking", false);
            }
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

        if (attack)
        {
            attackFlag = true;
        }
    }
}
