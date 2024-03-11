using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class EatingController : MonoBehaviour
{
    [SerializeField]
    private SizeController selfSize;
    [SerializeField]
    private DeathController deathController;

    void Start()
    {
        selfSize = GetComponent<SizeController>();
        deathController = GetComponent<DeathController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled) return;

        if (other.gameObject.TryGetComponent<Food>(out Food food))
        {
            if (food.TryEaten(selfSize.size))
            {
                selfSize.IncrementSize();
                UpdateScore(other.gameObject);
            }
            else
            {
                deathController.OnDeath();
            }
        }
    }

    private void UpdateScore(GameObject food)
    {
        if (food.TryGetComponent<ScoreController>(out ScoreController scoreController))
        {
            Debug.Log(scoreController.score);
            // TODO: Add score to GameManager
        }
    }
}
