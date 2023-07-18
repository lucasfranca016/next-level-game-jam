using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementation : MonoBehaviour
{
    public GameObject pointA, pointB;
    private Rigidbody2D rb;
    public float speed;
    private float initPositionA, initPositionB, currentPoint, transformAxisPosition;
    public Vector2 velocity, newVelocity;
    private GameObject childCollider;

    void Start()
    {
        initPositionB = pointB.transform.position.y;
        initPositionA = pointA.transform.position.y;
        velocity = new Vector2(0, speed);
        currentPoint = initPositionB;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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

        newVelocity = rb.velocity;
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
