using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActionCode2D.Renderers;

public class PlayerMovement : MonoBehaviour {

    public PlayerController controller;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteGhostTrailRenderer spriteGhost;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch;
    public Vector2 velocity;

    private float runStored;
    public bool isRunning;
	// Update is called once per frame
	void Update () {
        velocity = rb.velocity;

        horizontalMove =  runSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    
    public void Jump()
    {
            jump = true;
            anim.SetBool("isJumping", true);
    }

    public void Run()
    {
        if(!isRunning)
        {
            runStored = runSpeed;

            runSpeed *= 2;
            isRunning = true;
            spriteGhost.enabled = true;
        }
        else
        {
            runSpeed = runStored;
            isRunning = false;
            spriteGhost.enabled = false;
        }
    }

    public void OnLanding()
    {
        // if(controller.m_Grounded)
        Debug.Log("f");
        anim.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        anim.SetBool("isCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
