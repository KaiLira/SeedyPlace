using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    RequireComponent(typeof(TargetHolder)),
    RequireComponent(typeof(Rigidbody))
]
public class MoveTowardsTarget : MonoBehaviour
{
    public float speed;
    private Transform target;
    private Rigidbody body;

    private void Start()
    {
        target = GetComponent<TargetHolder>().target.transform;
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        body.velocity = (target.position - transform.position).normalized * speed;
    }
}
