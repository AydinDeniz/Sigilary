using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAfterXSeconds : MonoBehaviour
{
    AudioSource sound;
    public float timer = 2f;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.PlayDelayed(timer);
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
