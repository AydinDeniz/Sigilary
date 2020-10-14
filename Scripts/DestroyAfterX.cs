using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterX : MonoBehaviour
{
    public float secs;
    void Start()
    {
        Destroy(gameObject, secs);
    }

   
}
