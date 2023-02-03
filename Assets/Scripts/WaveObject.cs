using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles sending relevant information to the wave manager when recquired
/// </summary>
public class WaveObject : MonoBehaviour
{
    public WaveManager manager;
    public GameObject treePrefab;

    public void Despawn()
    {
        manager.WaveObjectDestroyed();
        Instantiate(treePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
