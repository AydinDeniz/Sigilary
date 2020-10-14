using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMover : MonoBehaviour
{
    public float speed;
    public int jumpCount;
    public float jumpForce;
    public Transform bones;
    public Transform[] wisps;
    public bool goingRight=true;
    private Animator anim;
    private float moveInput;
    private Rigidbody2D rig;
    private bool curFlip = true;

    private bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask[] whatIsGround;
    private int curJumpCount;
    private bool clGroundCheck;
    public string way = "d";

    private float oldVel = 0;
    private bool stunned = false;
    public bool gonnaJump = false;

    public void Wait(float secs)
    {
        stunned = true;
        Invoke("StopWaiting", secs);
    }

    public void StopWaiting()
    {
        stunned = false;
    }


    public void ChangeWay()
    {
        goingRight = !goingRight;
    }

    public void Jump()
    {
        gonnaJump = true;
        Invoke("ResetJump", 1f);
    }

    private void Flip(bool dir)
    {
        if (dir != curFlip)
        {
            bones.localScale = new Vector2(bones.localScale.x, -bones.localScale.y);
            
            curFlip = dir;
        }
    }

    private void CheckWisps()
    {
        foreach (Transform wisp in wisps)
        {
            if (Physics.Linecast(transform.position, wisp.position))
            {
                print("cant see");

            }
            else
            {
                print("can see");
            }
        }
    }

    void Start()
    {
        curJumpCount = jumpCount;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("Speed", speed);
        //InvokeRepeating("CheckWisps", 1f, 1f);
    }

    private void Update()
    {
        float velChange = oldVel - rig.velocity.y;
        anim.SetFloat("velChange", velChange);
        if (velChange < -5)
        {
            stunned = true;
            StartCoroutine(waitStun(0.3f));
        }


        anim.SetFloat("velocityY", rig.velocity.y);

        if (isGround == true && clGroundCheck == true)
        {

            curJumpCount = jumpCount;
        }



        anim.SetBool("Jumping", false);
        anim.SetBool("Running", false);
        moveInput = 0;
        if (stunned == false)
        {
            if (goingRight)
            {
                Flip(true);
                anim.SetBool("Running", true);
                moveInput = 1;
            }
            else if (!goingRight)
            {
                Flip(false);
                anim.SetBool("Running", true);
                moveInput = -1;
            }
            if (gonnaJump && curJumpCount > 0)
            {
                rig.velocity = Vector2.up * jumpForce;
                curJumpCount--;
                anim.SetBool("Jumping", true);
                clGroundCheck = false;
                StartCoroutine(waitCheckGround());
            }
            if (gonnaJump && clGroundCheck == false)
            {
                rig.velocity = Vector2.up * jumpForce * 3f;
            }
            else if (gonnaJump)
            {
                ResetJump();
            }
        }
        oldVel = rig.velocity.y;
        
    }

    public void ResetJump()
    {
        gonnaJump = false;
    }

    void FixedUpdate()
    {
        isGround = false;
        foreach (LayerMask mask in whatIsGround)
        {
            bool temp = Physics2D.OverlapCircle(groundCheck.position, checkRadius, mask);
            isGround = isGround || temp;
        }
        anim.SetBool("Ground", isGround);
        rig.velocity = new Vector2(moveInput * speed, rig.velocity.y);
    }

    private IEnumerator waitCheckGround()
    {
        yield return new WaitForSeconds(0.3f);
        clGroundCheck = true;
    }

    private IEnumerator waitStun(float time)
    {
        yield return new WaitForSeconds(time);
        stunned = false;
    }
}
