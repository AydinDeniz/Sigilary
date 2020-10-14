using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAura : MonoBehaviour
{
    public float enterRadius;
    public float exitRadius;
    public bool preserveMomentum=false;

    public Material litMat;
    public Material RedMat;
    public GameObject redEffect;
    private List<Rigidbody2D> pausedRigs = new List<Rigidbody2D>();
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
            if (obje.layer==11 || obje.layer ==14)
            {
                if (preserveMomentum)
                {
                    if (!obje.GetComponent<RedContainer>())
                    {
                        print("hit");
                        
                        Rigidbody2D rig = obje.GetComponent<Rigidbody2D>();
                        RedContainer container = obje.AddComponent<RedContainer>();
                        container.vel = rig.velocity;
                        container.anglerVel = rig.angularVelocity;
                        rig.bodyType = RigidbodyType2D.Static;
                        obje.GetComponent<SpriteRenderer>().material = RedMat;
                        if (!pausedRigs.Contains(rig))
                        {
                            GameObject summon = Instantiate(redEffect);
                            summon.transform.position = obje.transform.position;
                            pausedRigs.Add(rig);
                        }
                    }
                }
                else
                {
                    
                    Rigidbody2D rig = obje.GetComponent<Rigidbody2D>();
                    
                    if (!pausedRigs.Contains(rig))
                    {
                        if (obje.GetComponent<RewindTime>())
                        {
                            obje.GetComponent<RewindTime>().StopRewind();
                            obje.GetComponent<RewindTime>().cantRewind = true;
                        }
                        rig.bodyType = RigidbodyType2D.Static;
                        obje.GetComponent<SpriteRenderer>().material = RedMat;
                        GameObject summon = Instantiate(redEffect);
                        summon.transform.position = obje.transform.position;
                        pausedRigs.Add(rig);
                    }
                }
            }
        }
        cols = Physics2D.OverlapCircleAll(transform.position, exitRadius);
        for (int i=0;i<pausedRigs.Count;i++)
        {
            if (ArrayContains(cols,pausedRigs[0].gameObject.GetComponent<Collider2D>()))
            {

            }
            else
            {
                if (preserveMomentum)
                {
                    if (pausedRigs[0].GetComponent<RewindTime>())
                    {
                        pausedRigs[0].GetComponent<RewindTime>().frozen = true;
                    }
                    pausedRigs[0].GetComponent<SpriteRenderer>().material = litMat;
                    pausedRigs[0].bodyType = RigidbodyType2D.Dynamic;
                    pausedRigs[0].velocity = pausedRigs[0].GetComponent<RedContainer>().vel;
                    pausedRigs[0].angularVelocity = pausedRigs[0].GetComponent<RedContainer>().anglerVel;
                    Destroy(pausedRigs[0].GetComponent<RedContainer>(), 1);
                    pausedRigs.RemoveAt(0);
                    i--;
                }
                else
                {
                    if (pausedRigs[0].GetComponent<RewindTime>())
                    {
                        pausedRigs[0].GetComponent<RewindTime>().cantRewind = false;
                    }
                    pausedRigs[0].GetComponent<SpriteRenderer>().material = litMat;
                    if (pausedRigs[0].tag != "static")
                    {
                        pausedRigs[0].bodyType = RigidbodyType2D.Dynamic;
                    }
                    if (pausedRigs[0].GetComponent<RewindTime>())
                    {
                        pausedRigs[0].GetComponent<RewindTime>().frozen = true;
                    }
                    
                    pausedRigs.RemoveAt(0);
                    i--;
                }
            }
        }


    }

    bool ArrayContains(Collider2D[] array, Collider2D c)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == c) return true;
        }
        return false;
    }
}
