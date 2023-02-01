using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Sends out UnityEvents when the object it's attatched to is enabled or
/// disabled
/// </summary>
public class ActiveToEvents : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onEnable;
    [SerializeField]
    private UnityEvent _onDisable;

    private void OnEnable()
    {
        _onEnable?.Invoke();
    }

    void OnDisable()
    {
        _onDisable?.Invoke();
    }
}
