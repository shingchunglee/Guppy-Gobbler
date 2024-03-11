using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    public int size { private set; get; } = 1;

    public Transform transformComponent;

    private void Start()
    {
        transformComponent = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetSize(size + 1);
        }

    }

    public void IncrementSize()
    {
        SetSize(size + 1);
    }

    public void SetSize(int newSize)
    {
        size = newSize;
        transformComponent.localScale = new Vector3(size, size, size);
    }
}
