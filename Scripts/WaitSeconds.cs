using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSeconds : MonoBehaviour
{
    public GameObject[] activateOnTrigger;
    public float sec=3;
    private Collider2D other1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other1 = other;
            Invoke("Act", 0.1f);
        }
    }

    private void Act()
    {
        if (other1.gameObject.tag == "Player")
        {
            if (other1.GetComponent<autoMover>())
            {
                other1.GetComponent<autoMover>().Wait(sec);
            }
            foreach (GameObject obje in activateOnTrigger)
            {
                obje.SetActive(true);
            }
        }
    }
}
