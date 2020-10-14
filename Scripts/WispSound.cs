using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispSound : MonoBehaviour
{
    public float soundSpeed;
    private AudioSource aus;
    public float maxSound;
    private int counter = 0;
    private float sum=0;
    private Vector2 oldpos;
    private float targetVolume = 0;
    private void Start()
    {
        oldpos = transform.position;
        aus = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        
        if (counter == 1)
        {

            targetVolume = sum / (1 * maxSound);
            counter = 0;
            sum = 0;
        }
        else
        {
            sum += Vector2.Distance(transform.position,oldpos);
            counter++;
        }

        if(aus.volume < targetVolume)
        {
            aus.volume += soundSpeed;
        }
        else
        {
            aus.volume -= soundSpeed;
        }

        oldpos = transform.position;
    }
}
