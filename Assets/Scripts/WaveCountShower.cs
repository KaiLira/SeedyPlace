using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveCountShower : MonoBehaviour
{
    public Text text;

    public void WaveStarted(int number)
    {
        text.text = "Wave " + number;
        StartCoroutine(showFor(3f));
    }

    IEnumerator showFor(float seconds)
    {
        yield return new WaitForSeconds(seconds / 2f);
        text.enabled = true;
        yield return new WaitForSeconds(seconds);
        text.enabled = false;
    }
}
