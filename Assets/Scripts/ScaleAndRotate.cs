using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Randomizes scale and rotation so that the object looks somewhat unique
/// </summary>
public class ScaleAndRotate : MonoBehaviour
{
    void Start()
    {
        float yaw = Random.value * 360f;
        float scale = Random.Range(-1f, 1f) * 0.1f;

        transform.Rotate(0, yaw, 0);
        transform.localScale *= 1 + scale;
    }
}
