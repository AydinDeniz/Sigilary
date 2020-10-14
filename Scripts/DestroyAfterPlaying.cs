using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPlaying : MonoBehaviour
{
    AudioSource aus;
    void Start()
    {
        aus = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (!aus.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
