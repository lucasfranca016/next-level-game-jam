using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject pointA, pointB;
    public Rigidbody2D rb;
    public float speed;
    private float initPositionA, initPositionB, currentPoint, transformAxisPosition;
    public Vector2 velocity;

    void Start()
    {
        initPositionB = pointB.transform.position.y;
        initPositionA = pointA.transform.position.y;
        velocity = new Vector2(0, speed);

        currentPoint = initPositionB;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AddVelocity();

        ChangePatrolPoint();
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
    }

    private void ChangePatrolPoint()
    {
        transformAxisPosition = transform.position.y;
        
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
