using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryReciever : MonoBehaviour
{
    public AudioSource Parry;
    
    void SuccesfulParry()
    {
        if (!Parry.isPlaying)
        {
            Parry.Play();

            Debug.Log("Parreo");
        }
        else
        {
            Parry.Stop();
        }
    }

}
