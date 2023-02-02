using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHolder : MonoBehaviour
{
    public GameObject target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
}
