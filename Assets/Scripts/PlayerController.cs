using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 350f;
    
    public bool GameOver;
    public int Counter;
    public AudioClip AsBoing;
    public AudioClip AsBlip;
    public AudioClip AsBoom;
    private AudioSource PlayerAudioSource;
    public ParticleSystem ExplosionParticleSystem;
    public ParticleSystem FireworkParticleSystem;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        PlayerAudioSource = GetComponent<AudioSource>();
        GameOver = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
            PlayerAudioSource.PlayOneShot(AsBoing, 1f);
        }

    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!GameOver)
        {
            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                GameOver = true;
            }

            if (otherCollider.gameObject.CompareTag("Bomb"))
            {
                GameOver = true;
                Destroy(otherCollider.gameObject);
                PlayerAudioSource.PlayOneShot(AsBoom, 1f);
                ExplosionParticleSystem.Play();
            }

            if (otherCollider.gameObject.CompareTag("Money"))
            {
                Destroy(otherCollider.gameObject);
                Counter += 1;
                PlayerAudioSource.PlayOneShot(AsBlip, 1f);
                FireworkParticleSystem.Play();
            }
        }
    }
}
