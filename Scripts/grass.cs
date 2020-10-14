using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour
{
    public float range=0.1f;
    public float threshhold;
    private Animator anim;
    private float timer=-10;
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("Check", 0.3f, 0.05f);
    }

    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
    }

    private void Check()
    {
        if (timer < 0)
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range);
            foreach (Collider2D col in cols)
            {
                if (col.GetComponent<Rigidbody2D>())
                {
                    Rigidbody2D rig = col.GetComponent<Rigidbody2D>();
                    if (rig.bodyType == RigidbodyType2D.Dynamic)
                    {
                        if (rig.velocity.sqrMagnitude > threshhold)
                        {
                            if (rig.transform.position.x < transform.position.x)
                            {
                                anim.SetTrigger("right");
                                timer = 1;
                            }
                            else
                            {
                                anim.SetTrigger("left");
                                timer = 1;
                            }
                        }
                    }
                }
            }
        }
        else if (timer < -10)
        {
            timer = -1;
        }
    }
}
