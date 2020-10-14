using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBox : MonoBehaviour
{
    private bool fadeIn=false;
    private bool fadeOut = false;
    public GameObject player;
    private float curVolume;
    private float steps;
    private int counter = 0;
    private AudioSource aus;
    public void FadeOut(float secs,AudioClip clip)
    {
        foreach(Transform obje in transform)
        {
            if(clip == obje.GetComponent<AudioSource>().clip)
            {
                aus = obje.GetComponent<AudioSource>();
                break;
            }
        }
        steps = secs * 50;
        curVolume = aus.volume;
        fadeOut = true;
        counter = 0;
    }

    public void FadeIn(float secs, float volume,AudioClip clip,float pitch,bool loop)
    {
        foreach(Transform obje in transform)
        {
            if (obje.GetComponent<AudioSource>().clip == clip)
            {
                return;
            }
        }
        GameObject summon = Instantiate(player);
        summon.transform.parent = transform;
        if (!loop)
        {
            summon.AddComponent<DestroyAfterPlaying>();
        }
        aus = summon.GetComponent<AudioSource>();
        aus.loop = loop;
        aus.clip = clip;
        aus.volume = 0;
        aus.pitch = pitch;
        aus.Play();
        fadeIn = true;
        counter = 0;
        curVolume = volume;
        steps = 50*secs;
        if (steps == 0)
        {
            steps = 1;
        }
    }

    private void FixedUpdate()
    {
        
        if (fadeOut)
        {
            counter++;
            aus.volume -= curVolume / steps;
            if (counter == steps)
            {
                fadeOut = false;
                Destroy(aus.gameObject);
            }
        }
        else if (fadeIn)
        {
            counter++;
            aus.volume += curVolume / steps;
            if (counter == steps)
            {
                fadeIn = false;
            }
            
        }
        else
        {
            counter = 0;
        }
        
    }
}
