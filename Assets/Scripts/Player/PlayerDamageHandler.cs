using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AcornHolder))]
public class PlayerDamageHandler : MonoBehaviour
{
    public UnityEvent onDamaged;
    public UnityEvent onDeath;
    private AcornHolder acorns;

    private void Start()
    {
        acorns = GetComponent<AcornHolder>();
    }

    public void OnDamaged()
    {
        if (!acorns.TakeAcorn())
            onDeath?.Invoke();
        else
            onDamaged?.Invoke();
    }
}
