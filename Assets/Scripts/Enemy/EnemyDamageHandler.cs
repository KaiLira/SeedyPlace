using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles death timer for the enemies
/// </summary>
public class EnemyDamageHandler : MonoBehaviour
{
    public float totalTime;
    public UnityEvent onDeath;
    public float currentTime = -0.2f;

    public void OnDamaged()
    {
        currentTime += 2f;
    }

    public void HastenTime(float seconds)
    {
        if (currentTime > 0)
            currentTime += seconds;
    }

    private void Update()
    {
        if (currentTime >= 0f)
            currentTime += Time.deltaTime;

        if (currentTime >= totalTime)
            onDeath?.Invoke();
    }
}
