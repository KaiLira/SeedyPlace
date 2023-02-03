using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public GameObject waveObject;
    public int size;
    public int growthRate;
    public UnityEvent<int> waveStarted;
    private int activeCount;
    private int currentWave = 1;

    private void StartWave()
    {
        activeCount = size + currentWave * growthRate;
        for (int i = 0; i < activeCount; i++)
        {
            var location = transform.GetChild(Random.Range(0, transform.childCount));
            var obj = Instantiate(waveObject, location.position, location.rotation);
            obj.GetComponent<WaveObject>().manager = this;
        }

        waveStarted?.Invoke(++currentWave);
    }

    private void Update()
    {
        if (activeCount <= 0)
        {
            StartWave();
        }
    }

    /// <summary>
    /// Must be called by WaveObject on "death"
    /// </summary>
    public void WaveObjectDestroyed()
    {
        if (--activeCount <= 0)
            StartWave();
    }
}
