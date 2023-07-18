using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject pointA, pointB, pointC, pointD;
    private Rigidbody2D rb;
    public string movimentationMode;
    public float speed;
    private float initPositionA, initPositionB, currentPoint, transformAxisPosition;
    public Vector2 velocity,newVelocity;
    private GameObject childCollider;

    void Start()
    {
        childCollider = transform.GetChild(4).gameObject;

        if (movimentationMode == "h")
        {
            initPositionB = pointB.transform.position.x;
            initPositionA = pointA.transform.position.x;
            velocity = new Vector2(speed, 0);
        }

        if (movimentationMode == "v")
        {
            initPositionB = pointD.transform.position.y;
            initPositionA = pointC.transform.position.y;
            velocity = new Vector2(0, speed);
        }
        currentPoint = initPositionB;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AddVelocity();

        ChangePatrolPoint();

        childCollider.SetActive(true);
    }

    private void AddVelocity()
    {
        if (currentPoint == initPositionB)
        {
            rb.velocity = velocity * -1;
        }
        if (currentPoint == initPositionA)
        {
            rb.velocity = velocity;
        }

        newVelocity = rb.velocity;
    }

    private void ChangePatrolPoint()
    {
        if (movimentationMode == "h")
        {
            transformAxisPosition = transform.position.x;
        }
        if (movimentationMode == "v")
        {
            transformAxisPosition = transform.position.y;
        }

        if (transformAxisPosition >= initPositionA)
        {
            currentPoint = initPositionB;
        }
        if (transformAxisPosition <= initPositionB)
        {
            currentPoint = initPositionA;
        }
    }
}
