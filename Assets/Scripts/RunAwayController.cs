using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayController : MonoBehaviour
{
    [SerializeField]
    private jellyfishMovement jellyfishMovement;

    [SerializeField]
    private SizeController playerSize;

    private void Awake()
    {
        // Find the player GameObject by tag
        jellyfishMovement = GetComponent<jellyfishMovement>();

        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        if (playerGameObject != null)
        {
            playerSize = playerGameObject.GetComponent<SizeController>();
        }

    }


    private void FixedUpdate()
    {
        // Debug.Log("Size: " + $"{playerSize.size}" + " SizeController: " + $"{GetComponent<SizeController>().size + 2}");
        if (playerSize.size > GetComponent<SizeController>().size + 2)//@roy i tried to change the size on size controller but it doesnt reflect when played so i tested without this condition
        {
            checkRayCast();
        }
    }

    private void checkRayCast()
    {
        Vector2 currentDirection = jellyfishMovement.GetDirection().normalized;
        Collider2D collider = GetComponent<Collider2D>();
        float colliderHeight = collider.bounds.size.y;
        float raycastLength = collider.bounds.size.x*2;
        int numberOfRays = 5; //because one line isnt enough to detect, wanted at full height of the collider >.< maybe we can reduce to 3 upto u
        float spacing = colliderHeight / (numberOfRays - 1);

        for (int i = 0; i < numberOfRays; i++)
        {

            float verticalOffset = (i * spacing) - (colliderHeight / 2);
            Vector2 rayStartPos = new Vector2(transform.position.x, transform.position.y + verticalOffset);

            Debug.DrawRay(rayStartPos, currentDirection * raycastLength, Color.red, 4f);

            RaycastHit2D hit = Physics2D.Raycast(rayStartPos, currentDirection, raycastLength, LayerMask.GetMask("Player"));// i cant set a proper length cus of the fish size so it might not even appear on screen at 20 pls fix when sprite gets bigger, might need to increase raycast length
            if (hit.collider != null)
            {
                // if (hit.collider.CompareTag("Player"))
                // {
                RunAway();
                break; // Optional: stop checking further rays if player is already detected
                // }
            }
        }
    }


    private void RunAway()
    {
        Vector2 currentDirection = jellyfishMovement.GetDirection();
        Vector2 escapeDirection = -currentDirection;
        jellyfishMovement.SetDirection(escapeDirection);
        jellyfishMovement.FlipJelly();
    }
}

