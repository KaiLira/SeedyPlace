using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockReceiver : MonoBehaviour
{
    public AudioSource Block;
    void SuccesfulBlock()
    {
        if (!Block.isPlaying)
        {
            Block.Play();

            Debug.Log("Bloqueo");
        }
        else
        {
            Block.Stop();
        }
    }
}
