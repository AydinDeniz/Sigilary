using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public bool Fixed=false;
    public float distance;
    public float char_distance;
    public Transform cam;

    private Vector2 old_cam_pos;
    private Vector3 offset;
    private void Start()
    {
        if (Fixed == true)
        {
            offset = transform.position - cam.position;
            transform.SetParent(cam);
        }
        else
        {
            old_cam_pos = cam.position;
        }
    }

    void Update()
    {
        if (Fixed == false)
        {
            float cam_movementX = -old_cam_pos.x + cam.position.x;
            float cam_movementY = -old_cam_pos.y + cam.position.y;

            if (cam_movementX != 0)
            {
                transform.position = new Vector2(transform.position.x + cam_movementX * char_distance / distance, transform.position.y);
            }

            if (cam_movementY != 0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + cam_movementY * char_distance / distance);
            }
            old_cam_pos = cam.position;
        }
        else
        {
            transform.SetParent(cam);
        }
    }
}
