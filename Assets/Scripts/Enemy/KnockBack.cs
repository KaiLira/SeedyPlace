using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KnockBack : MonoBehaviour
{
    public float magnitude;
    public float ghostTime;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Knockback()
    {
        float yaw = rb.transform.rotation.eulerAngles.y;
        var force = Utils.Vec3FromComps(20f, 270f - yaw, magnitude);
        rb.AddForce(force, ForceMode.Impulse);
        StartCoroutine(ghosting(ghostTime));
    }

    private IEnumerator ghosting(float seconds)
    {
        rb.detectCollisions = false;
        yield return new WaitForSeconds(seconds);
        rb.detectCollisions = true;
    }
}
