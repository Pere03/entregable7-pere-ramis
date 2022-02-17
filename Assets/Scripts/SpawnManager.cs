using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Obstaculos;
    public float startDelay = 2f;
    public float repeatRate = 4f;
    private PlayerController playerControllerScript;    

    void Start()
    {
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {

    }

    public Vector3 RandomSpawnPosition1()
    {
        return new Vector3(10, Random.Range(2, 14), 0);
    }

    public Vector3 RandomSpawnPosition2()
    {
        return new Vector3(-10, Random.Range(2, 14), 0);
    }
    
    public void SpawnObstacles()
    {
        float randomNumber = Random.Range(0, 3);
        int randomIndex = Random.Range(0, Obstaculos.Length);

        if (!playerControllerScript.GameOver)
        {
            if (randomNumber == 1 && !playerControllerScript.GameOver)
            {
                Instantiate(Obstaculos[randomIndex], RandomSpawnPosition1(), Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            else
            {
                Instantiate(Obstaculos[randomIndex], RandomSpawnPosition2(), Obstaculos[randomIndex].transform.rotation);
            }
        }      
    }
}
