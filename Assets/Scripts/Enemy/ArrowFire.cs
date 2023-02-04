using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFire : MonoBehaviour
{
    public GameObject arrow;

    public void FireArrow()
    {
        var proj = Instantiate(arrow, transform.position, transform.rotation);
        proj.tag = tag;
    }
}
