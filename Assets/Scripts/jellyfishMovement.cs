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

    void FlipJelly()
{
    if (jmoveDirection == Vector2.right)
    {
       
        transform.localScale = new Vector3(-1, 1, 1);
    }
    else
    {
       
        transform.localScale = new Vector3(1, 1, 1);
    }
}

}
