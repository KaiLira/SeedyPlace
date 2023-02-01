using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class FireHandler : MonoBehaviour
{
    public GameObject projectile;
    public Transform throwPoint;
    public AcornHolder acorns;
    public UnityEvent fired;
    private bool corrector = false;

    public void OnFire(InputAction.CallbackContext context)
    {
        corrector = !corrector;
        if (corrector || !context.ReadValueAsButton() || !isActiveAndEnabled)
            return;

        if (!acorns.TakeAcorn())
            return;

        var proj = Instantiate(projectile);
        proj.transform.SetPositionAndRotation(throwPoint.position, throwPoint.rotation);
        fired?.Invoke();
    }
}
