using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotateTowardsMovement : MonoBehaviour
{
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float yaw = Vector3.SignedAngle
            (Vector3.forward, body.velocity, Vector3.up);

        transform.rotation = Quaternion.Euler(0, yaw, 0);
    }
}
