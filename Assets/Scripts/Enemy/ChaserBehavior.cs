using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehavior : MonoBehaviour
{
    public EnemyHealth health;
    
    private Vector3 speed;
   
    Camera cam;
    CameraBounds camBounds;
    Bounds bound;
   
    private float nextFire;
    public float fireRate;

    GameObject hero;
    GameObject[] players;

    private float timeSinceSpawn, timeAtSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.setHealth(1, 1);
        
        speed = new Vector3(0, -35f, 0);
        speed = speed * Time.fixedDeltaTime;

        cam = Camera.main;
        camBounds = cam.GetComponent<CameraBounds>();
        bound = camBounds.bounds;

        players = GameObject.FindGameObjectsWithTag("Player");

        fireRate = 0.50f;
        nextFire = 0f;

        timeSinceSpawn = 0;
        timeAtSpawn = Time.time;

        transform.Rotate(Vector3.forward * 180f);


    }

    void FixedUpdate()
    {
        
        hero = players[Random.Range(0,1)];
        
        shoot();
        transform.Translate(-speed);
        if(timeSinceSpawn < 5.5f)
        {
            PointAtPosition(hero.transform.position, .25f);
        }
        else
        {
            Destroy(gameObject);
        }
        
        if(transform.position.y < bound.min.y)
        {
            Destroy(gameObject);
        }
        timeSinceSpawn = Time.time - timeAtSpawn;
    }


    /// <summary>
    /// This points the top of the enemy at the specified position, at the specified rate.
    /// </summary>
    /// <param name="p">The position to point to.</param>
    /// <param name="r">The rate at which we should turn towards it.</param>
    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.position;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }

    //Tells Chaser to shoot projectiles.
    void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Resources.Load("Prefabs/Bullet"), transform.position + Vector3.up, transform.rotation);
        }
    }
}
