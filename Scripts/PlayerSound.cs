using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    public AudioClip footStepLeft;
    public AudioClip footStepRight;
    public AudioClip fall;
    public AudioSource audioS;
    private bool left = true;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FootStepLeft()
    {

        audioS.Stop();
        audioS.clip = footStepLeft;
        audioS.Play();
    }
    void FootStepRight()
    {
        if (left)
        {
            FootStepLeft();
            left = false;
        }
        else
        {
            left = true;
            audioS.Stop();
            audioS.clip = footStepRight;
            audioS.Play();
        }
    }
    void FallSound()
    {
        audioS.PlayOneShot(fall);
    }
}
