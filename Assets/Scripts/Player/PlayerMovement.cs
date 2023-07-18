using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator anima;
    private MovingPlatform movingPlatScript;
    public Rigidbody2D rb;
    public BoxCollider2D col;
    private float horizontal, vertical;
    public float speed;
    public bool isFacingRight = true, isCrouch = false;

    public Transform groundCheck;
    public LayerMask groundLayer, platformLayer;
    public float ColliderYsize = 1.3f;
    private Vector2 ColliderSize, platformVelocity;
    private PlayerJump jumpScript;

    void Start()
    {
        ColliderSize = col.size;
        jumpScript = GetComponent<PlayerJump>();
    }

    void Update()
    {
        Flip();
        Crouch();
    }

    private void FixedUpdate()
    {
        if (isCrouch)
        {
            if (isOnPlatform())
            {
                rb.velocity = new Vector2(0, rb.velocity.y) + platformVelocity;
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        else
        {
            if (isOnPlatform())
            {
                rb.velocity = new Vector2(horizontal * speed, 0) + platformVelocity;
            }
            else
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }

        }
    }
    private void Crouch()
    {
        if ((vertical == -1f) && (isGrounded()))
        {
            col.size = new Vector2(ColliderSize.x, ColliderYsize);
            isCrouch = true;

            jumpScript.UpdateIsCrouch(true);

            anima.SetBool("IsCrouching", true);
            anima.SetBool("IsRunning", false);
        }

        if ((vertical != -1f) && (col.size.y == ColliderYsize))
        {
            col.size = ColliderSize;
            isCrouch = false;

            jumpScript.UpdateIsCrouch(false);

            anima.SetBool("IsCrouching", false);
        }

    }
    public void UpdateVelocity(Vector2 vel)
    {

        platformVelocity = vel;
        Debug.Log(platformVelocity);

    }

    public void UpdateArrows(float verticalValue, float horizontalValue)
    {
        horizontal = horizontalValue;
        vertical = verticalValue;
        //correndo
        if ( (horizontal != 0) && (isGrounded()) )
        {
            anima.SetBool("IsRunning", true);
        }else
        {
            anima.SetBool("IsRunning", false);
        }
        //pulando
        if (isGrounded())
        {
            anima.SetBool("IsJumpping", false);
        }
        else
        {
            anima.SetBool("IsJumpping", true);
        }
        //agachando
    }

    private void Flip()
    {

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {

            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
            //Vector3 localScale = transform.localScale;
            //localScale.x *= -1f;
            //transform.localScale = localScale;

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isOnPlatform())
        {
            platformVelocity = collision.gameObject.GetComponent<MovingPlatform>().velocity;
            Debug.Log("Colidi com plataforma");
        }
    }
    bool isOnPlatform()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.15f), CapsuleDirection2D.Horizontal, 0, platformLayer);
    }
    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.15f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
