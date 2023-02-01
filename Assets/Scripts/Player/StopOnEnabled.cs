using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When the object is enabled, it sets the player's velocity to zero
/// </summary>
public class StopOnEnabled : MonoBehaviour
{
    public Rigidbody player;

    private void OnEnable()
    {
        player.velocity = Vector3.zero;
    }
}
