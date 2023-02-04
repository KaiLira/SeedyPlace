using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KnockBack : MonoBehaviour
{
    public float magnitude;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Knockback()
    {
        float yaw = rb.transform.rotation.eulerAngles.y;
        var force = Utils.Vec3FromComps(20f, 90 + yaw, magnitude);
        rb.AddForce(force, ForceMode.Impulse);
    }
}
