using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerColor : MonoBehaviour
{
    public Color color1;
    public Color color2;
    private Vector2 scale1;

    private void Start()
    {
        scale1 = transform.localScale;
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = color1;
        transform.localScale *= 1.1f;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = color2;
        transform.localScale = scale1;
    }
}
