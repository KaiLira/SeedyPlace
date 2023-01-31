using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Modifies character's yaw according to player input
/// </summary>
public class TurnHandler : MonoBehaviour
{
    public float turnRate;
    public Transform player;
    private float intention = 0;

    public void OnControllerLook(InputAction.CallbackContext context)
    {
        Vector2 intentionVector = context.ReadValue<Vector2>();

        if (intentionVector == Vector2.zero)
            return;

        intention = - Vector2.SignedAngle(Vector2.up, intentionVector);
    }

    private void Update()
    {
        float yaw = player.rotation.eulerAngles.y;
        yaw = Mathf.Lerp(yaw, intention, turnRate);

        player.rotation = Quaternion.Euler(0, yaw, 0);
    }
}
