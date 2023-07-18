using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform CameraTarget;
    public float cameraYdifference;

    void Update()
    {
        Vector3 newPos = new Vector3(CameraTarget.position.x, CameraTarget.position.y + cameraYdifference, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
