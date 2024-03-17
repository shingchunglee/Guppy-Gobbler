using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OutlineController : MonoBehaviour
{
    public GameObject outlineObject;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OutlineOn()
    {
        outlineObject.SetActive(true);
    }

    public void OutlineOff()
    {
        outlineObject.SetActive(false);
    }

    public void FlipX()
    {
        outlineObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void DontFlipX()
    {
        outlineObject.GetComponent<SpriteRenderer>().flipX = false;
    }
}
