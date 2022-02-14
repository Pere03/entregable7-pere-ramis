using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 500f;
    private float MaxYRange = 17f;
    public bool GameOver;
    public int Counter;
    private AudioSource Boing;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        GameOver = false;
        Boing = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
            Boing.Play();
        }

        if (transform.position.y > MaxYRange)
        {
            transform.position = new Vector3(transform.position.x, MaxYRange, transform.position.z);
        }

    }



    private void OnCollisionEnter(Collision otherCollider)
    {
        if (GameOver = true)
        {
            Time.timeScale = 0;
            Debug.Log("GAME OVER");
        }

        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            GameOver = true;
        }

        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
        }

        if (otherCollider.gameObject.CompareTag("Money"))
        {
            Destroy(otherCollider.gameObject);
            Counter += 1;
        }
    }
}
