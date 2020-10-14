using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int jumpCount;
    public float jumpForce;
    public Transform bones;
    public Transform[] wisps;

    private Animator anim;
    private float moveInput;
    private Rigidbody2D rig;
    private bool curFlip = true;

    private bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int curJumpCount;
    private bool clGroundCheck;


    private float oldVel=0;
    private bool stunned = false;

    private void Flip(bool dir)
    {
        if (dir != curFlip)
        {
            bones.localScale = new Vector2(bones.localScale.x,-bones.localScale.y);
            curFlip = dir;
        }
    }

    private void CheckWisps()
    {
        foreach(Transform wisp in wisps)
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


        anim.SetFloat("velocityY",rig.velocity.y);

        if(isGround == true && clGroundCheck==true)
        {
            
            curJumpCount = jumpCount;
        }

        

        anim.SetBool("Jumping", false);
        anim.SetBool("Running", false);
        moveInput = 0;
        if (stunned == false)
        {
            if (Input.GetKey("d"))
            {
                Flip(true);
                anim.SetBool("Running", true);
                moveInput = 1;
            }
            else if (Input.GetKey("a"))
            {
                Flip(false);
                anim.SetBool("Running", true);
                moveInput = -1;
            }
            if (Input.GetKeyDown(KeyCode.Space) && curJumpCount > 0)
            {
                rig.velocity = Vector2.up * jumpForce;
                curJumpCount--;
                anim.SetBool("Jumping", true);
                clGroundCheck = false;
                StartCoroutine(waitCheckGround());
            }
            if (Input.GetKey(KeyCode.Space) && clGroundCheck == false)
            {
                rig.velocity = Vector2.up * jumpForce * 3f;
            }
        }
        oldVel = rig.velocity.y;
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
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
