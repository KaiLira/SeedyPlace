using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public GameObject raccoon;
    public GameObject porcupine;
    public int raccoonCount;
    public int porcupineCount;
    public int raccoonGrowthRate;
    public int porcupineGrowthRate;
    public float downTime;
    public UnityEvent<int> waveStarted;
    private int activeCount;
    private int currentWave = -1;

    private void Start()
    {
        StartCoroutine(startWave());
    }

    private IEnumerator startWave()
    {
        waveStarted?.Invoke(++currentWave + 1);
        yield return new WaitForSeconds(downTime);

        var activeRaccoons = raccoonCount + currentWave * raccoonGrowthRate;
        for (int i = 0; i < activeRaccoons; i++)
        {
            var location = transform.GetChild(Random.Range(0, transform.childCount));
            var obj = Instantiate(raccoon, location.position, location.rotation);
            obj.GetComponent<WaveObject>().manager = this;
        }

        var activePorcupines = porcupineCount + currentWave * porcupineGrowthRate;
        for (var i = 0; i < activePorcupines; i++)
        {
            var location = transform.GetChild(Random.Range(0, transform.childCount));
            var obj = Instantiate(porcupine, location.position, location.rotation);
            obj.GetComponent<WaveObject>().manager = this;
        }

        activeCount = activeRaccoons + activePorcupines;
    }

    /// <summary>
    /// Must be called by WaveObject on "death"
    /// </summary>
    public void WaveObjectDestroyed()
    {
        if (--activeCount <= 0)
            StartCoroutine(startWave());
    }
}
