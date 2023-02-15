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
    public AudioSource Guamazo;

    /// <summary>
    /// Returns a float between 0 and 1 of how long the entity has to live
    /// 0 being full health and 1 being death
    /// </summary>
    public float DeathProgress()
    {
        if (currentTime < 0f)
            return 0f;

        return Mathf.Clamp01(currentTime / totalTime);
    }
    
    public void OnDamaged()
    {
        currentTime += 2f;
        Guamazo.Play();
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
