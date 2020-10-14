using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateOnStart : MonoBehaviour
{
    public GameObject Transition;
    void Start()
    {
        Transition.SetActive(true);
    }

    
}
