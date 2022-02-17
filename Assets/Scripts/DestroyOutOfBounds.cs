using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float rightLim = 18f;
    private float lefthLim = -18f;

    void Update()
    {
        if (transform.position.x > rightLim)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < lefthLim)
        {
            Destroy(gameObject);
        }
    }
}
