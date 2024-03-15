using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerControllerMitch : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float moveSpeedMax;


    public event Action PlayerDied;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This has been changed from 0.02 to 0.01, which should result in smoother physics.
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 &&
            Input.GetAxisRaw("Vertical") == 0)
        {

        }

        rb.AddForce(Vector3.right * moveSpeed * Input.GetAxis("Horizontal"),
                ForceMode2D.Impulse);

        rb.AddForce(Vector3.up * moveSpeed * Input.GetAxis("Vertical"),
                ForceMode2D.Impulse);


        ClampSpeed();


    }

    void ClampSpeed()
    {

        var xSpeed = Mathf.Abs(rb.velocity.x);
        var ySpeed = Mathf.Abs(rb.velocity.y);


        if (xSpeed > moveSpeedMax ||
            ySpeed > moveSpeedMax)
        {
            rb.velocity = new Vector2(

                //This limits the x move speed to the Limit
                Mathf.Clamp(rb.velocity.x, -moveSpeedMax, moveSpeedMax),

                //This limits the y move speed to the Limit
                Mathf.Clamp(rb.velocity.y, -moveSpeedMax, moveSpeedMax)
                );
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Shark"))
        {
            PlayerDied.Invoke();
            Destroy(this.gameObject);
        }
    }
}
