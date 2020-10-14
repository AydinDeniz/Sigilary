using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPressScene : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<NextLevelOnTrigger>().LoadPublic();
        }
    }
}
