using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    public GameObject[] activateOnTrigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.GetComponent<autoMover>().goingRight == true)
                other.GetComponent<autoMover>().goingRight = false;
            else if (other.GetComponent<autoMover>().goingRight == false)
                other.GetComponent<autoMover>().goingRight = true;
            foreach(GameObject obje in activateOnTrigger)
            {
                obje.SetActive(true);
            }
        }
    }
}
