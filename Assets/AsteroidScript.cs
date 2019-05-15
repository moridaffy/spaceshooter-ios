using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    public float rotationSpeed;
    public float minSpeed;
    public float maxSpeed;

    public GameObject explosion;
    public GameObject playerExplosion;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;

        asteroid.velocity = Vector3.back * Random.RandomRange(minSpeed, maxSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameArea" || other.tag == "Asteroid") {
            return;
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }

        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().increaseScore(1);
        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
