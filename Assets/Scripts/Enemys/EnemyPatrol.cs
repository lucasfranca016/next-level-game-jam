using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA, pointB;
    private Rigidbody2D rb;
    public string init = "a", movementType = "p";
    public float speed, initPositionA, initPositionB, currentPoint;
    private bool isFacingRight = true;
    public Transform[] Transformers;

    //private Animator anim;

    void Start()
    {
        Transformers = this.GetComponentsInChildren<Transform>();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        initPositionB = pointB.transform.position.x;
        initPositionA = pointA.transform.position.x;
        if(init == "a")
        {
            currentPoint = initPositionA;
        }
        else
        {
            currentPoint = initPositionB;
        }
        //anim.SetBool("isRunning", true);
    }

    void Update()
    {
        AddVelocity();

        if(movementType == "p")
        {
            ChangePatrolPoint();
        }

        Flip();
    }

    private void AddVelocity()
    {
        if (currentPoint == initPositionB)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (currentPoint == initPositionA)
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }

    private void ChangePatrolPoint()
    {
        if (transform.position.x >= initPositionA)
        {
            currentPoint = initPositionB;
        }
        if (transform.position.x <= initPositionB)
        {
            currentPoint = initPositionA;
        }
    }

    private void Flip()
    {

        if ((isFacingRight && rb.velocity == new Vector2(-speed, 0)) || (!isFacingRight && rb.velocity == new Vector2(speed, 0)))
        {

            isFacingRight = !isFacingRight;
            Transformers[2].Rotate(0f, 180f, 0f);
            transform.Rotate(0f, 180f, 0f);

        }

    }
}
