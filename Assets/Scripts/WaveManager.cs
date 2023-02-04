using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public GameObject waveObject;
    public int size;
    public int growthRate;
    public float downTime;
    public float minWait;
    public float maxWait;
    public UnityEvent<int> waveStarted;
    private int activeCount;
    private int currentWave = -1;

    private void Start()
    {
        StartCoroutine(startWave());
    }

    private IEnumerator startWave()
    {
        waveStarted?.Invoke(++currentWave);
        yield return new WaitForSeconds(downTime);

        activeCount = size + currentWave * growthRate;
        for (int i = 0; i < activeCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            var location = transform.GetChild(Random.Range(0, transform.childCount));
            var obj = Instantiate(waveObject, location.position, location.rotation);
            obj.GetComponent<WaveObject>().manager = this;
        }
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
