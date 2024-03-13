using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharkMovement : MonoBehaviour
{
    public float smoveSpeed = 5f;
    private Vector2 smoveDirection;

    void Start()
    {
        sleftOrRight();
        FlipShark();
    }

    void Update()
    {
        MoveShark();
    }

    void MoveShark()
    {
        transform.Translate(smoveDirection * smoveSpeed * Time.deltaTime);
    }

    void sleftOrRight()
    {
        int direction = Random.Range(0, 2); 
    if (direction == 0)
    {
        smoveDirection = Vector2.left;
    }
    else
    {
        smoveDirection = Vector2.right;
    }

        
        FlipShark();
    }

    void FlipShark()
{
    if (smoveDirection == Vector2.right)
    {
       
        transform.localScale = new Vector3(-1, 1, 1);
    }
    else
    {
       
        transform.localScale = new Vector3(1, 1, 1);
    }
}

}
