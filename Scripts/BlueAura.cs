using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAura : MonoBehaviour
{
    public float enterRadius;
    public GameObject blueEffect;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, enterRadius);
        foreach (Collider2D col in cols)
        {

            GameObject obje = col.gameObject;
            if (obje.layer == 11 || obje.layer==14)
            {
                if (obje.GetComponent<RewindTime>())
                {
                    RewindTime rewinder = obje.GetComponent<RewindTime>();
                    if (!rewinder.isRewinding && !rewinder.cantRewind)
                    {
                        if (obje.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
                        {
                            GameObject summon = Instantiate(blueEffect);
                            summon.transform.position = obje.transform.position;
                            rewinder.StartRewind();
                        }
                    }
                    else
                    {
                        rewinder.ResetTimer();
                    }
                }
            }
        }

        


    }

    
}
