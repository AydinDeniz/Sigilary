﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePause : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<autoMover>().speed = 0f;
            other.GetComponent<Animator>().enabled = false;
        }
    }
}
