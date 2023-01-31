using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateForward : MonoBehaviour
{
    public float turnRate;

    void Update()
    {
        transform.Rotate(new Vector3(turnRate, 0, 0) * Time.deltaTime);
    }
}

