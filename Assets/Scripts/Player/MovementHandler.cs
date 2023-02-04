using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Processes movement input and converts it to velocity to be set
/// to a rigidbody
/// </summary>
public class MovementHandler : MonoBehaviour
{
    public float Speed;
    public Rigidbody player;
    private Vector2 intention = Vector2.zero;
    public AudioSource patas;

    public void OnMove(InputAction.CallbackContext context)
    {
        intention = context.ReadValue<Vector2>() * Speed;
    }

    void FixedUpdate()
    {
        float prevY = player.velocity.y;
        player.velocity = new Vector3(intention.x, prevY, intention.y);

        if (player.velocity != Vector3.zero)
        {
            patas.Play();
            Debug.Log("Iniciar musica");
        }
        else
        {
            patas.Stop();
            Debug.Log("Parar musica");
        }
    }
}
