using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AcornHolder))]
public class DamageHandler : MonoBehaviour
{
    private AcornHolder acorns;

    private void Start()
    {
        acorns = GetComponent<AcornHolder>();
    }

    public void OnDamaged()
    {
        if (!acorns.TakeAcorn())
            Debug.Log("It is death");
    }
}
