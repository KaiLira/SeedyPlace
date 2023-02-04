using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanaDistancia : MonoBehaviour
{
    GameObject mapache;
    void Start()
    {
        mapache= GameObject.FindWithTag("Mapache");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
