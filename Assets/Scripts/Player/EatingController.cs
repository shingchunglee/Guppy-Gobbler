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

    void Awake()
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
                GameManager.Instance.soundManager.Sound_EatFish();
            }
            else if (food.TryEatPlayer(selfSize.size))
            {
                deathController.OnDeath();
            }
        }

        if (other.gameObject.CompareTag("Shark"))
        {
            GameManager.Instance.soundManager.Sound_HitShark();
            deathController.OnDeath();
        }

        if (other.gameObject.CompareTag("Jellyfish"))
        {
            GameManager.Instance.soundManager.Sound_HitJelly();
            deathController.OnDeath();
        }
    }

    private void UpdateScore(GameObject food)
    {
        if (food.TryGetComponent<ScoreController>(out ScoreController scoreController))
        {
            Debug.Log(scoreController.score);
            // TODO: Add score to GameManager

            GameManager.Instance.AddScore(scoreController.score);
        }
    }
}
