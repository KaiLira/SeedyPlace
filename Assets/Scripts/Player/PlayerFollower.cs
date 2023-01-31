using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.InputSystem;

/// <summary>
/// Handles Camera movement for the player, including following the
/// player around, changing the angle according to input as well as
/// moving to avoid obstructions.
/// </summary>
public class PlayerFollower : MonoBehaviour
{
    public Transform m_player;
    public float m_targetPitch;
    public float m_targetYaw;
    public float m_targetDistance;
    public float m_speed;
    public float m_sensitivity = 75;
    private Vector2 m_intention = Vector2.zero;

    void FixedUpdate()
    {
        // Modify angles with input
        m_targetYaw -= m_intention.x * m_sensitivity * Time.fixedDeltaTime;
        m_targetYaw %= 360f;
        m_targetPitch = Mathf.Clamp(
            m_targetPitch - m_intention.y * m_sensitivity * Time.fixedDeltaTime,
            5,
            80
            );
        m_targetPitch = Mathf.Abs(m_targetPitch) % 360f;

        // Get the target position for the camera
        Vector3 targetPos = Utils.Vec3FromComps
            (m_targetPitch, m_targetYaw, m_targetDistance)
            + m_player.position;

        // Check for collidiers obstructing view
        if (Physics.Raycast(
            m_player.position,
            (targetPos - m_player.position),
            out RaycastHit hit,
            (targetPos - m_player.position).magnitude
            ))
        {
            targetPos = hit.point;
        }

        // Lerp the position of the camera
        transform.position = Vector3.Lerp
            (transform.position, targetPos, m_speed * Time.fixedDeltaTime);
    }

    public void LookInput(InputAction.CallbackContext context)
    {
        m_intention = context.ReadValue<Vector2>();
    }
}
