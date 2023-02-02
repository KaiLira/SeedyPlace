using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTarget : MonoBehaviour
{
    public TargetHolder holder;
    public Transform raccoon;

    private void Update()
    {
        float yaw = Vector3.SignedAngle(
            Vector3.back,
            raccoon.position - holder.target.transform.position,
            Vector3.up
            );

        raccoon.rotation = Quaternion.Euler(0, yaw, 0);
    }
}
