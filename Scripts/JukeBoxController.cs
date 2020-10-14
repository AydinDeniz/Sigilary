using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBoxController : MonoBehaviour
{
    public bool secsMode=false;
    public float secs;
    public bool fadeIn = true;
    private JukeBox jukeBox;
    [Header("fadeIn")]
    public bool loop = true;
    public float secsIn;
    public float volume;
    public AudioClip clipIn;
    public float pitch=1;
    [Header("fadeOut")]
    public float secsOut;
    public AudioClip clipOut;
    void Start()
    {
        jukeBox = GameObject.FindGameObjectWithTag("JukeBox").GetComponent<JukeBox>();
        if (secsMode)
        {
            Invoke("Act", secs);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<autoMover>())
        {
            if (fadeIn)
            {
                jukeBox.FadeIn(secsIn, volume, clipIn,pitch,loop);
            }
            else
            {
                jukeBox.FadeOut(secsOut, clipOut);
            }
        }
    }

    private void Act()
    {
        if (fadeIn)
        {
            jukeBox.FadeIn(secsIn, volume, clipIn,pitch,loop);
        }
        else
        {
            jukeBox.FadeOut(secsOut, clipOut);
        }
    }
}
