using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject waveObject;
    public int size;
    private int activeCount;

    private void Start()
    {
        StartWave();
    }

    private void StartWave()
    {
        activeCount = size;
        for (int i = 0; i < size; i++)
        {
            var location = transform.GetChild(Random.Range(0, transform.childCount));
            var obj = Instantiate(waveObject, location.position, location.rotation);
            obj.GetComponent<WaveObject>().manager = this;
        }
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
        activeCount--;
    }
}
