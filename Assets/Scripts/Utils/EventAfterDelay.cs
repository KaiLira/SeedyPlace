using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Invokes a unity event after a set delay
/// </summary>
public class EventAfterDelay : MonoBehaviour
{
    public float m_delay;
    public bool m_looping = false;
    public bool m_autostart = true;
    public UnityEvent m_event;
    private Coroutine m_coroutine = null;

    void OnEnable()
    {
        if (m_autostart)
            StartTimer();
    }

    public void StartTimer()
    {
        StopTimer();
        m_coroutine = StartCoroutine(invokeAfter());
    }

    private IEnumerator invokeAfter()
    {
        yield return new WaitForSeconds(m_delay);
        m_event?.Invoke();

        if (m_looping)
            StartTimer();
    }

    public void StopTimer()
    {
        if (m_coroutine != null)
            StopCoroutine(m_coroutine);
    }

    private void OnDisable()
    {
        StopTimer();
    }
}
