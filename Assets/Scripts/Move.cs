using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;
    private PlayerController playerControllerScript;

    void Start()
    {
        //Con esto accedemos al player y sus componentes, y la declaramos en playerControllerScript
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        //Si el gameover esta desactivado, el objeto se movera hacia una direccion, en este caso hacia la derecha

        if (!playerControllerScript.GameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
