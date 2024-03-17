using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyfishMovement : MonoBehaviour
{
    public float jmoveSpeed = 5f;
    private Vector2 jmoveDirection;

    void Start()
    {
        //jleftOrRight();
        FlipJelly();
    }

    void Update()
    {
        MoveJelly();
    }

    void MoveJelly()
    {
        transform.Translate(jmoveDirection * jmoveSpeed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        jmoveDirection = direction;
    }

    //void jleftOrRight()
    //{
    //        int direction = Random.Range(0, 2); 
    //if (direction == 0)
    //{
    //    jmoveDirection = Vector2.left;
    //}
    //else
    //{
    //    jmoveDirection = Vector2.right;
    //}


    //    FlipJelly();
    //}

    public Vector2 GetDirection()
    {
        return jmoveDirection;
    }

    public void FlipJelly()
    {
        if (jmoveDirection == Vector2.right)
        {

            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<OutlineController>().FlipX();
        }
        else
        {

            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<OutlineController>().DontFlipX();
        }
    }

}
