using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private SizeController selfSize;

    void Start()
    {
        selfSize = GetComponent<SizeController>();
    }

    public bool TryEaten(int otherSize)
    {
        if (selfSize.size + 2 <= otherSize)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
