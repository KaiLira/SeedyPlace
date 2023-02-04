using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocationGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position + Vector3.up, 1);
    }
}
