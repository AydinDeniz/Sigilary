using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnCollision : MonoBehaviour
{
    public AudioSource source;
    private bool played = false;
    private void Start()
    {

        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(!played &&(collision.gameObject.layer==8 || collision.gameObject.layer == 14)) {

            source.Play();
            played = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 14)
        {
            played = false;
            source.Stop();
        }
    }
}
