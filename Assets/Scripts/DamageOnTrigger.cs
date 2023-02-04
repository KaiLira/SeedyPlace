using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Calculates whether an entity should take damage when a collision is detected
/// </summary>
public class DamageOnTrigger : MonoBehaviour
{
    public UnityEvent onParried;
    public UnityEvent onHit;

    /// <summary>
    /// The colliders hit within the last physics frame
    /// </summary>
    private List<Collider> hits = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        hits.Add(other);
    }

    /// <summary>
    /// Each physics frame resolves wether there was a hit, a block or a parry
    /// </summary>
    private void FixedUpdate()
    {
        if (hits.Count == 0)
            return;

        var parry = hits.Find(hit => hit.CompareTag("Parry"));
        if (parry != null)
        {
            onParried?.Invoke();

            hits = new List<Collider>();
            return;
        }

        var block = hits.Find(hit => hit.CompareTag("Block"));
        if (block != null)
        {
            onHit?.Invoke();

            hits = new List<Collider>();
            return;
        }

        var equal = hits.Find(hit => hit.CompareTag(tag));
        if (equal != null)
        {
            hits = new List<Collider>();
            onHit?.Invoke();
            return;
        }

        foreach (var hit in hits)
            hit.gameObject.SendMessage
                ("OnDamaged", SendMessageOptions.DontRequireReceiver);

        onHit?.Invoke();
        hits = new List<Collider>();
    }
}
