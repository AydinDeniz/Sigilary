using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispCursor : MonoBehaviour
{
    public float speed=3;
    public Camera cam;
    public float radius;
    public Transform wisp;
    public bool leftControlled = true;
    private Vector3 mouseMovement;
    private Vector3 oldPos;

    private void Start()
    {
        oldPos = transform.position;
        transform.position = wisp.position;
    }

    void Update()
    {
        if (leftControlled)
        {

                

            Cursor.lockState = CursorLockMode.Locked;
            if ((wisp.position - transform.position).sqrMagnitude > radius)
            {
                transform.position = oldPos;
            }
            oldPos = transform.position;


                transform.position += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        }
        else
        {
            if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonUp(1))
            {
                transform.position = wisp.position;
            }
            Cursor.lockState = CursorLockMode.Locked;
            if ((wisp.position - transform.position).sqrMagnitude > radius)
            {
                transform.position = oldPos;
            }
            oldPos = transform.position;
            if (Input.GetMouseButton(1))
            {
                transform.position += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            }
        }
    }
}
