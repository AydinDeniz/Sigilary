using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTime : MonoBehaviour
{
    //Special Thanks to Brackeys
    public Material blueMat;
    public bool isRewinding = false;
    public float recordTime = 10f;
    public int i = 0;
    public int j = 0;
    public int counter = 0;
    List<PointInTime> pointsInTime;
    private PointInTime startPoint;
    Rigidbody2D rb;
    private float timer =-20;
    private Material lit;
    public bool frozen=false;
    public bool cantRewind = false;
    void Start()
    {
        lit = GetComponent<SpriteRenderer>().material;
        startPoint = new PointInTime(transform.position, transform.rotation);
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody2D>();
    }

   

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer < 0 &&timer>-10)
        {
            timer = -20;
            StopRewind();
        }
        else if (timer < -20)
        {
            timer = -20;
        }
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    void Rewind()
    {
        if(GetComponent<SpriteRenderer>().material != blueMat)
        {
            GetComponent<SpriteRenderer>().material = blueMat;
        }
        counter = 0;
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            transform.position = startPoint.position;
            transform.rotation = startPoint.rotation;
        }
    }
    void Record()
    {
        if(pointsInTime.Count > 10)
        {
            if(pointsInTime[0].position == pointsInTime[1].position && pointsInTime[0].rotation == pointsInTime[1].rotation)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
        }

        if (counter > 10)
            if (frozen)
            {
                counter = 0;
                frozen = false;
                if (isRewinding)
                {
                    GetComponent<SpriteRenderer>().material = blueMat;
                }
            }
            else if (pointsInTime[0].position!=transform.position || pointsInTime[0].rotation!=transform.rotation)
            {
                counter = 0;
                if (isRewinding)
                {
                    GetComponent<SpriteRenderer>().material = blueMat;
                }
            }
            else
            {
                return;
            }


        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        j++;
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    public void StartRewind()
    {
        if (GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
        {

            GetComponent<SpriteRenderer>().material = blueMat;
            isRewinding = true;
            if (rb)
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
            timer = 2;
        }
    }

    public void ResetTimer()
    {
        timer = 2;
    }

    public void StopRewind()
    {
        if (!cantRewind)
        {
            frozen = false;
            if (isRewinding)
            {
                GetComponent<SpriteRenderer>().material = lit;
            }
            isRewinding = false;
            if (rb)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
