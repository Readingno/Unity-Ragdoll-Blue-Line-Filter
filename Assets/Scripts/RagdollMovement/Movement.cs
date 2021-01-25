using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Animator animator;
    public Rigidbody rb;
    public FootOnGround leg1;
    public FootOnGround leg2;
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public float turnTime;
    float turnSpeed;
    bool isOnGround, isWalk, isRun, isWave;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckOnGround();
        Jump();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0f, v).normalized;
        animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        if (dir.magnitude > 0f)
        {
            //Change rotation of the character
            float targetAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            float currentAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, turnTime);
            transform.rotation = Quaternion.Euler(0f, currentAngle, 0f);
            //Change position and animation
            if (Input.GetKey("left shift") || Input.GetKey("right shift"))
            {
                //rb.velocity = new Vector3(dir.x * runSpeed, rb.velocity.y, dir.z * runSpeed);
                transform.position += dir * runSpeed * Time.deltaTime;
                animator.SetFloat("Speed", 2f, 0.1f, Time.deltaTime);
            }
            else
            {
                //rb.velocity = new Vector3(dir.x * walkSpeed, rb.velocity.y, dir.z * walkSpeed);
                transform.position += dir * walkSpeed * Time.deltaTime;
                animator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
            }
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isOnGround = false;
            leg1.onGround = false;
            leg2.onGround = false;
            animator.SetBool("IsGround", false);
        }
    }

    void CheckOnGround()
    {
        if (leg1.onGround || leg2.onGround)
        {
            isOnGround = true;
            animator.SetBool("IsGround", true);
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnGround = true;
            animator.SetBool("IsGround", true);
        }
    }*/
}
