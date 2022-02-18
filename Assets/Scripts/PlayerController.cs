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
        //Con esto podemos acceder a la componente rigidbody del player, y la guardamos en playerRigidbody
        playerRigidbody = GetComponent<Rigidbody>();

        //Con esto podemos acceder a la componente AudioSource del player, y la guardamos en playerAudioSource
        PlayerAudioSource = GetComponent<AudioSource>();

        //Esto declara que gameover vale false desde que inicia
        GameOver = false;
    }

    
    void Update()
    {
        //Con esto hacemos que si pulsamos la tecla espacio y no esta game over activado, el player dara un salto y ademas hara un sonido

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
            //Si el player hace contacto con un objeto con el tag "Ground", se activara el gameover
            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                GameOver = true;
            }

            //Si el player hace contacto con un objeto con el tag "Bomb", se activara el gameover, reproducira un sonido de explosion y activara unas particulas de explosion
            if (otherCollider.gameObject.CompareTag("Bomb"))
            {
                GameOver = true;
                Destroy(otherCollider.gameObject);
                PlayerAudioSource.PlayOneShot(AsBoom, 1f);
                ExplosionParticleSystem.Play();
            }

            //Si el player hace contacto con un objeto con el tag "Money", destruira el objeto, le aumentara 1 al contador, reproducira un sonido y activara unas particulas
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
