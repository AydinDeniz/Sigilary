using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToMouse : MonoBehaviour
{
    public Camera cam;
    private SpriteRenderer rend;
    private void Start()
    {
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();        
    }

    void Update()
    {
        Vector2 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mouse.x+rend.bounds.extents.x,mouse.y-rend.bounds.extents.y);
    }
}
