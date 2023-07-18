using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public Rigidbody2D rb;

    [Header("Jump System")]
    public int jumpPower;
    public float fallMultiplier, jumpTime, jumpMultiplier;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private Vector2 vecGravity;

    private bool isJumping, isCrouch=false;
    private float jumpCounter;

    private void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }

        if((rb.velocity.y > 0) && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if(jumpCounter>jumpTime) isJumping = false;

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if (t > 0.5)
            {
                currentJumpM = jumpMultiplier * (1 - t);
            }


            rb.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
        }
    }

    public void Jump()
    {

        if ((isGrounded()))
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCounter = 0;
        }

    }

    public void endJump()
    {
        isJumping = false;
        jumpCounter = 0;

        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.15f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    public void UpdateIsCrouch(bool value)
    {
        isCrouch = value;
    }
}
