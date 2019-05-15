using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    public float tilt;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    public float shotDelay;
    private float nextShot;

    public GameObject laserShot;
    public Transform laserGun;
    private GameControllerScript gameController;

    private Rigidbody ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    private void Update()
    {
        if (!gameController.isStarted())
        {
            return;
        }

        bool canShoot = Time.time > nextShot;
        if (Input.GetButton("Fire1") && canShoot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(laserShot, laserGun.position, Quaternion.Euler(0, 0, 0));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(xPosition, 0, zPosition);
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);
    }
}
