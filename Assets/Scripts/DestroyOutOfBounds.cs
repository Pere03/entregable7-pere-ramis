using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float rightLim = 18f;
    private float lefthLim = -18f;

    void Update()
    {
        //Cuando el objeto llegue hacia alguna de las 2 posiciones declaradas, el objeto se destruira

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
