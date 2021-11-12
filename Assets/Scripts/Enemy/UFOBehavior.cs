using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBehavior : MonoBehaviour
{
    public EnemyHealth health;

    private Vector3 speed;
    
    Camera cam;
    CameraBounds camBounds;
    Bounds bound;
    
    private float nextFire;
    public float fireRate;

    private float timeSinceSpawn, timeAtSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        health.setHealth(8, 1);
        
        speed = new Vector3(0, -40f, 0);
        speed = speed * Time.fixedDeltaTime;

        cam = Camera.main;
        camBounds = cam.GetComponent<CameraBounds>();
        bound = camBounds.bounds;

        fireRate = 0.225f;
        nextFire = 0f;

        timeSinceSpawn = 0;
        timeAtSpawn = Time.time;

        transform.Rotate(Vector3.forward * 180f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float direction = spin(30f);
        if(timeSinceSpawn > 2.5f && timeSinceSpawn < 10f)
        {
            transform.Rotate(Vector3.forward * spin(30f) * Time.fixedDeltaTime);
            shoot();
        }
        else
        {
            transform.Translate(speed, Space.World);
            Debug.Log("TRANSLATING DOWN");
            if(transform.position.y < bound.min.y - 10)
            {
                Destroy(gameObject);
            }
        }

        timeSinceSpawn = Time.time - timeAtSpawn;
    }

    float spin(float spd)
    {
        if(this.transform.position.x < 0)
        {
            return spd;
        }
        else
        {
            return -spd;
        }
    }
    
    //Tells UFO to shoot projectiles.
    void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, transform.rotation);
            GameObject behind = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, transform.rotation) as GameObject;
            GameObject right = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, transform.rotation) as GameObject;
            GameObject left = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, transform.rotation) as GameObject;

            if(transform.position.x < 0)
            {
                behind.transform.Rotate(Vector3.forward * 180f);
                right.transform.Rotate(Vector3.forward * 90f);
                left.transform.Rotate(Vector3.forward * -90f);
            }
            else if(transform.position.x >= 0)
            {
                behind.transform.Rotate(Vector3.forward * 180f);
                right.transform.Rotate(Vector3.forward * -90f);
                left.transform.Rotate(Vector3.forward * 90f);
            }   
        }
    }

}

