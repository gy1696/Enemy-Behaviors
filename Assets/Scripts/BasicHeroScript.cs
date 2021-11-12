using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHeroScript : MonoBehaviour
{
    public EnemySpawnControl e;
    private float nextFire;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.225f;
        nextFire = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float s = Input.GetAxis("Vertical") * .3f;
        float side = Input.GetAxis("Horizontal") * .5f;

        if(Input.GetKey("w") || Input.GetKey("s"))
        {
            this.transform.position += Vector3.up * s;
        }
        if(Input.GetKey("a") || Input.GetKey("d"))
        {
            this.transform.position += Vector3.right * side;
        }

        if(Input.GetKeyDown("z"))
        {
            e.SpawnUFO();
        }

        if(Input.GetKeyDown("x"))
        {
            e.SpawnFighter();
        }

        if(Input.GetKeyDown("c"))
        {
            e.SpawnChaser();
        }

        if (Input.GetKey("space"))
        {
            shoot();
        }
    }

    void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Resources.Load("Prefabs/HeroBullet"), transform.position, transform.rotation);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy Bullet")
        {
            Destroy(col.gameObject);
            Debug.Log("HIT");
        }
    }
}
