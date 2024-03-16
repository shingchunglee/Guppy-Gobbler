using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runaway2 : MonoBehaviour
{
   
    [SerializeField]
    private jellyfishMovement jellyfishMovement;

   // [SerializeField]
   private SizeController playerSize;

    private void Awake()
    {
        jellyfishMovement = GetComponentInParent<jellyfishMovement>();

        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        if (playerGameObject != null)
        {
            playerSize = playerGameObject.GetComponent<SizeController>();
        }
    }

   private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player")) 
    {
        SizeController otherSize = other.GetComponent<SizeController>();
        if (otherSize != null && otherSize.size > GetComponentInParent<SizeController>().size + 2)
        {
            RunAway();
        }
    }
}

    private void RunAway()
{
    if (jellyfishMovement == null)
    {
        Debug.LogError("jellyfishMovement not there");
        return;
    }

    Vector2 currentDirection = jellyfishMovement.GetDirection();
    if (currentDirection == null)
    {
        Debug.LogError("cant get currentdirection");
        return;
    }

    Vector2 escapeDirection = -currentDirection;
    jellyfishMovement.SetDirection(escapeDirection);
    jellyfishMovement.FlipJelly();
}
}