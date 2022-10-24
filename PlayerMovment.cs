using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    float horizMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizMove));
        
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch= false;
        }

     }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(horizMove * Time.fixedDeltaTime,false,jump);
        jump = false;
    }
}
