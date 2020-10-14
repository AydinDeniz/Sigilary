using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasdController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private float cursorRadius;
    public float amount;
    public float maxSpeed = 15f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            if (Input.GetKey("w"))
            {
                dir.y += amount;
            }
            if (Input.GetKey("a"))
            {
                dir.x -= amount;
            }
            if (Input.GetKey("d"))
            {
                dir.x += amount;
            }
            if (Input.GetKey("s"))
            {
                dir.y -= amount;

            }
            dir = dir.normalized;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


            if ((maxSpeed * maxSpeed) >= ((rb.velocity.x * rb.velocity.x) + (rb.velocity.y * rb.velocity.y)))
            {

                rb.AddForce(dir * force);

            }
            else
            {

            }
        }
        rb.velocity = Vector2.zero;
    }
}
