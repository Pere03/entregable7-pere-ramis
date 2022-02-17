using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    public float repeatWidth;

    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2f;
    }

    void Update()
    {
        if (transform.position.x > startPosition.x + repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
