using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispToCursor : MonoBehaviour
{
    private Rigidbody2D rb;
    private float cursorRadius;
    private Vector2 oldPos;
    public bool leftMode = true;
    public float force;
    public Transform wispCursor;

    void Start()
    {
        oldPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        cursorRadius = wispCursor.gameObject.GetComponent<WispCursor>().radius;
    }

    void LateUpdate()
    {
        //Vector2 moveDirection = (Vector2)transform.position - oldPos;
        //if (moveDirection != Vector2.zero)
        //{
        //  float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //}
        //oldPos = transform.position;


        if (leftMode)
        {

                var dir = wispCursor.position - transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                rb.velocity = Vector2.zero;
                rb.AddForce(((wispCursor.transform.position - transform.position).normalized * force) * (rb.mass * rb.mass) * cursorRadius * (wispCursor.transform.position - transform.position).sqrMagnitude);

        }
        else
        {
            if (Input.GetMouseButton(1))
            {
                var dir = wispCursor.position - transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                rb.velocity = Vector2.zero;
                rb.AddForce(((wispCursor.transform.position - transform.position).normalized * force) * (rb.mass * rb.mass) * cursorRadius * (wispCursor.transform.position - transform.position).sqrMagnitude);
            }
        }
        
    }
}
