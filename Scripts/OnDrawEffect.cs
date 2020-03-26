using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDrawEffect : MonoBehaviour
{ 
    [SerializeField]
    public ParticleSystem leftEffect;
    public ParticleSystem rightEffect;


    private Vector3 old_Pos;
    private ParticleSystem.EmissionModule emL;
    private ParticleSystem.EmissionModule emR;

    private void Start()
    {
        old_Pos = transform.position;
        emL = leftEffect.emission;
        emR = rightEffect.emission;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (transform.position.x > old_Pos.x)
            {
                emL.enabled = false;
                emR.enabled = true;
            }
            else if (transform.position.x < old_Pos.x)
            {
                emL.enabled = true;
                emR.enabled = false;
            }
            else
            {
                emL.enabled = false;
                emR.enabled = false;
            }

        }
        
        old_Pos = transform.position;
    }
}
