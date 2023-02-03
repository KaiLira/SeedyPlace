using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles each wave's start, spawning and end.
/// </summary>
[CreateAssetMenu(
    fileName = "WaveManager",
    menuName = "ScriptableObjects/Create WaveManager"
)]
public class WaveManager : ScriptableObject
{

    /// <summary>
    /// Must be called by WaveObject on "death"
    /// </summary>
    public void WaveObjectDestroyed()
    {
    }
}
