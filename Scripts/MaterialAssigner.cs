using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAssigner : MonoBehaviour
{
    public Material blue;
    public Material red;
    public void Glow(string color)
    {
        if (color == "red") {
            GetComponent<SpriteRenderer>().material = red;
        }
        else
        {
            GetComponent<SpriteRenderer>().material = blue;
        }
    }
}
