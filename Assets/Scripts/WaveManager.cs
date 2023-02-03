using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject waveObject;

    private void Start()
    {
        var location = transform.GetChild(Random.Range(0, transform.childCount));
        var inst = Instantiate(waveObject, location.position, location.rotation);
        inst.GetComponent<WaveObject>().manager = this;
    }

    /// <summary>
    /// Must be called by WaveObject on "death"
    /// </summary>
    public void WaveObjectDestroyed()
    {
        Debug.Log("Raccoon died");
    }
}
