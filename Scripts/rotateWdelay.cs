using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateWdelay : MonoBehaviour
{
    public float rotSpeed = 20;
    private bool rotate = false;
    public float secs=3;
    void Start()
    {
        InvokeRepeating("Rotate", secs, secs);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
        }
        
    }

    public void Rotate()
    {
        rotate = true;
        Invoke("Stop", .5f);
        
    }

    public void Stop()
    {
        rotate = false;
    }
}
