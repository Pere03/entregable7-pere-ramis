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
        //Con esto hacemos invocaciones de forma repetitiva, con un valor para la primera vez que se invoca y otro valor para las siguientes veces que se repita
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);

        //Con esto accedemos al player y sus componentes, y la declaramos en playerControllerScript
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public Vector3 RandomSpawnPosition1()
    {
        //Con esto hacemos que devuelva un valor Vector3, que contiene un valor predeterminado en X y tambien un valor aleatorio en Y entre el 2 y el 14
        return new Vector3(10, Random.Range(2, 14), 0);
    }

    public Vector3 RandomSpawnPosition2()
    {
        //Con esto hacemos que devuelva un valor Vector3, que contiene un valor predeterminado en X y tambien un valor aleatorio en Y entre el 2 y el 14
        return new Vector3(-10, Random.Range(2, 14), 0);
    }
    
    public void SpawnObstacles()
    {
        float randomNumber = Random.Range(0, 3);
        int randomIndex = Random.Range(0, Obstaculos.Length);

       
        if (!playerControllerScript.GameOver)
        {
            //Si el gameover del player vale false y dependiendo de que numero aleatorio contenga randomNumber, iniciara una de las 2 instanciaciones siguientes

            if (randomNumber == 1 && !playerControllerScript.GameOver)
            {

            /*Si randomNumber vale 1, instanciara uno de los 2 obstaculos de forma aleatoria, con la posicion declarada en RandomSpawnPosition1, y tambien rotara 180 grados, 
              para que asi el obstaculo aparezca en la derecha y asi ira hacia la izquierda */
                Instantiate(Obstaculos[randomIndex], RandomSpawnPosition1(), Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            else
            {

            /*Si randomNumber vale cualquier otro numero que no sea 1, instanciara uno de los 2 obstaculos de forma aleatoria, con la posicion declarada en 
              RandomSpawnPosition2, para que asi el obstaculo aparezca en la izquierda y asi ira hacia la derecha*/
                Instantiate(Obstaculos[randomIndex], RandomSpawnPosition2(), Obstaculos[randomIndex].transform.rotation);
            }
        }      
    }
}
