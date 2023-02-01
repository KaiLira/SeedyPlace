using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Holds the variable that's used for both ammo and health
/// </summary>
public class AcornHolder : MonoBehaviour
{
    public int maxAcorns;
    private int currentAcorns;

    private void Start()
    {
        currentAcorns = maxAcorns;
    }

    public int Acorns
    {
        get { return currentAcorns; }
    }

    /// <summary>
    /// Lowers the current acorn count by one if the count is above zero, returns
    /// a boolean indicating whether this is possible
    /// </summary>
    /// <returns>Whether an acorn was able to be taken</returns>
    public bool TakeAcorn()
    {
        if (currentAcorns > 0)
        {
            currentAcorns--;
            return true;
        }
        else
            return false;
    }

    /// <summary>
    /// Adds the specified amount of acorns to the count if this is possible without going
    /// over the maximum acorn count, if a negative value is passed, it does nothing.
    /// </summary>
    public void AddAcorns(int amount)
    {
        currentAcorns = Math.Clamp
            (currentAcorns + amount, currentAcorns, maxAcorns);
    }
}