using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : TriggerAble
{
    
    [Header("Settings")]
    public float turnSpeed=2;
    public bool working = false;
    public bool reverseAtLimit = false;
    public bool hasOffState=false;
    public int turnOffDirection = 1;
    [Header("Optional")]
    public Collider2D limiterCol1;
    public Collider2D limiterCol2;
    public Transform jointPoint;
    public Collider2D offState;

    private bool turningOff=false;
    private float setSpeed;

    private void Start()
    {
        setSpeed = turnSpeed;
    }

    void FixedUpdate()
    {

        if (working == true)
        {
            transform.RotateAround(jointPoint.position, Vector3.forward, turnSpeed);

        }
        else if(turningOff == true && hasOffState == true)
        {

            transform.RotateAround(jointPoint.position, Vector3.forward, turnSpeed*turnOffDirection);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        try
        {

            if (coll == limiterCol1 || coll == limiterCol2 && turningOff == false)
            {

                if (reverseAtLimit == true)
                {
                    turnSpeed *= -1;
                }
                else
                {
                    turnSpeed = 0;
                }
            }
            else if (turningOff == true)
            {
                if (coll == offState)
                {
                    turningOff = false;
                }
            }
        }
        catch
        {
        }
    }


    override public void Trigger()
    {
        working = true;
    }

    override public void UnTrigger()
    {
        working = false;
        turningOff = true;
        if (reverseAtLimit == false)
        {
            turnSpeed = setSpeed;
        }
    }

}
