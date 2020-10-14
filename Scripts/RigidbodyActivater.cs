using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyActivater : MonoBehaviour
{
    public Rigidbody2D[] rigs;
    public float delay=0.3f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("Happen", delay);
            if (GetComponent<Animator>())
            {
                GetComponent<Animator>().SetTrigger("down");
            }
        }
    }

    public void Happen()
    {
        foreach (Rigidbody2D rig in rigs)
        {
            rig.bodyType = RigidbodyType2D.Dynamic;
            if (rig.gameObject.GetComponent<RewindTime>())
            {
                rig.gameObject.GetComponent<RewindTime>().frozen = true;
                rig.gameObject.GetComponent<RewindTime>().cantRewind = false;
            }
        }
    }
}
