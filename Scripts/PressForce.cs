using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressForce : MonoBehaviour
{
    public float ForceX = 0;
    public float ForceY = 5;
    public float Distance = 100;
    public float MaxSpeed = 5f;
    public Transform Touch;
    public bool trigger;
    private Vector2 Force = new Vector2(0,0);
    private float TouchY;
    private Vector2 Zero = new Vector2(0, 0);

    void Start()
    {
        Force = new Vector2(ForceX, ForceY);
        TouchY = Touch.transform.position.y;
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        trigger = true;
        Debug.Log("an1");
        this.GetComponent<Rigidbody2D>().velocity = Zero;
        /*
        while (this.GetComponent<Transform>().position.x < TouchY + Distance)
        {
            i++;
            Debug.Log("an2");
            if(this.GetComponent<Rigidbody2D>().velocity.y < MaxSpeed)
            {
                Vector2 deneme = new Vector2(ForceX, ForceY);
                this.GetComponent<Rigidbody2D>().AddRelativeForce(deneme);
            }
            if(i>2000)
            { break; }
        }
        this.GetComponent<Rigidbody2D>().velocity = Zero;
        i = 0;
        */
    }

    void FixedUpdate()
    {
        if(trigger)
        {
            if(this.GetComponent<Transform>().position.y < TouchY + Distance)
            {
                Debug.Log("an2");
                if (this.GetComponent<Rigidbody2D>().velocity.y < MaxSpeed)
                { 
                    Debug.Log("an3");
                    this.GetComponent<Rigidbody2D>().AddRelativeForce(Force);
                }
            }
            else if(this.GetComponent<Transform>().position.y >= TouchY + Distance)
            {
                Debug.Log("an4");
                this.GetComponent<Rigidbody2D>().velocity = Zero;
                trigger = false;
            }
            
        }
    }
}
