using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tork : MonoBehaviour
{
    Rigidbody2D rb;
    public float AngularVelocityLimit;
    public float force = 5;
      
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.angularVelocity >= AngularVelocityLimit)
        {
            //nothing
        }
        else if(rb.angularVelocity < AngularVelocityLimit)
        {
            rb.AddTorque(force, ForceMode2D.Impulse);
        }
    }
}
