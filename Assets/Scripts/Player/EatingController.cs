using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class EatingController : MonoBehaviour
{
    [SerializeField]
    private SizeController selfSize;

    void Start()
    {
        selfSize = GetComponent<SizeController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.gameObject.TryGetComponent<Food>(out Food food))
        {
            if (food != null)
            {
                if (food.TryEaten(selfSize.size))
                {
                    selfSize.IncrementSize();
                }
            }
        }
    }
}
