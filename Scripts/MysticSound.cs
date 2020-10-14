using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticSound : MonoBehaviour
{
    public AudioClip MysticEffect;
    public GameObject sideS;
    public float efectDuration = 7f;
    //public AudioSource sideS;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Mystic()
    {
        sideS.SetActive(true);
        Destroy(sideS, efectDuration);
    }
}
