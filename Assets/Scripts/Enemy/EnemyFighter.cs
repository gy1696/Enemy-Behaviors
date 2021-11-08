using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : MonoBehaviour
{
    private int health;
    private Vector3 speed;
    Camera cam;
    CameraBounds camBounds;
    Bounds bound;
    private float nextFire;
    public float fireRate;

    private float timeSinceSpawn, timeAtSpawn;

    void Start()
    {
        health = 1;
        speed = new Vector3(0, -30f, 0);
        speed = speed * Time.fixedDeltaTime;

        cam = Camera.main;
        camBounds = cam.GetComponent<CameraBounds>();
        bound = camBounds.bounds;

        fireRate = .75f;
        nextFire = 0f;

        timeSinceSpawn = 0;
        timeAtSpawn = Time.time;

        transform.Rotate(Vector3.forward * 180f);


    }

    void FixedUpdate()
    {
        transform.position += speed;
        shoot();
        if(transform.position.y < bound.min.y)
        {
            Destroy(gameObject);
        }
        timeSinceSpawn = Time.time - timeAtSpawn;
    }
    
    //Tells Fighter to shoot projectiles.
    void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Resources.Load("Prefabs/Bullet"), transform.position + Vector3.up, transform.rotation);
        }
    }

    public void decreaseHealth()
    {
        health--;
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

}