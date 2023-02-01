using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Takes a PlayerInput button input and exposes it as UnityEvents for when
/// pressed and released
/// </summary>
public class ButtonEvents : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _buttonPressed;
    [SerializeField]
    private UnityEvent _buttonReleased;
    private bool correction = false;

    public void OnButton(InputAction.CallbackContext ctx)
    {
        correction = !correction;
        if (correction)
            return;

        if (ctx.ReadValueAsButton())
            _buttonPressed?.Invoke();
        else
            _buttonReleased?.Invoke();
    }
}
