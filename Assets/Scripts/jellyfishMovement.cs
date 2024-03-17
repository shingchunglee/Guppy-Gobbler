using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (!gameObject.CompareTag("Shark"))
        {
            if (jmoveDirection == Vector2.right)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                if (TryGetComponent<OutlineController>(out OutlineController outlineController))
                {
                    outlineController.FlipX();
                };
            }
            else
            {

                GetComponent<SpriteRenderer>().flipX = false;
                if (TryGetComponent<OutlineController>(out OutlineController outlineController))
                {
                    outlineController.DontFlipX();
                };
            }
        }
        else
        {
            if (jmoveDirection == Vector2.left)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                if (TryGetComponent<OutlineController>(out OutlineController outlineController))
                {
                    outlineController.FlipX();
                };
            }
            else
            {

                GetComponent<SpriteRenderer>().flipX = false;
                if (TryGetComponent<OutlineController>(out OutlineController outlineController))
                {
                    outlineController.DontFlipX();
                };
            }
        }
    }

}
