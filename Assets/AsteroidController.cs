using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay;
    public float maxDelay;
    public float asteroidIncrease;

    private float nextSpawn;
    private float asteroidCount;
    private GameControllerScript gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    private void Update()
    {
        if (!gameController.isStarted())
        {
            return;
        }

        if (Time.time > nextSpawn)
        {

            float maxAsteroid = Random.Range(1, asteroidCount);
            for(int i = 0; i < maxAsteroid; i++)
            {
                nextSpawn = Time.time + Random.Range(minDelay, maxDelay);

                float scale = transform.localScale.x / 2;
                float randomXPosition = Random.Range(-scale, scale);
                Vector3 randomPosition = new Vector3(randomXPosition, transform.position.y, transform.position.z);
                Instantiate(asteroid, randomPosition, Quaternion.identity);
            }
            asteroidCount += asteroidIncrease;
        }
    }
}
