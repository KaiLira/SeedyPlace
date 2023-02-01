using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireHandler : MonoBehaviour
{
    public GameObject projectile;
    public Transform throwPoint;
    private bool corrector = false;

    public void OnFire(InputAction.CallbackContext context)
    {
        corrector = !corrector;
        if (corrector || !context.ReadValueAsButton() || !isActiveAndEnabled)
            return;

        var proj = Instantiate(projectile);
        proj.transform.SetPositionAndRotation(throwPoint.position, throwPoint.rotation);
    }
}
