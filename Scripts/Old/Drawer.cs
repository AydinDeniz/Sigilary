using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public Vector2[,] shapes;
    public List<Vector2> drawingPoints;

    private Camera cam;
    private bool held=false;

    static public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    private void Start()
    {
        drawingPoints = new List<Vector2>();
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            held = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            held = false;
        }

        if (held == true)
        {
            drawingPoints.Add((Vector2)GetWorldPositionOnPlane(Input.mousePosition,0));
            print((Vector2)GetWorldPositionOnPlane(Input.mousePosition, 0));
        }
    }
}
