using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandomizer : MonoBehaviour
{
    private Animator thisAnim;
    public string ClipName;
    void Start()
    {
        thisAnim = GetComponent<Animator>();
        thisAnim.Play(ClipName, -1, Random.Range(0.0f, 1.0f));
    }

    
}
