using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHeroScript : MonoBehaviour
{
    private float nextFire;
    public float fireRate;
    
    Camera cam;
    CameraBounds camBounds;
    Bounds bound;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        camBounds = cam.GetComponent<CameraBounds>();
        bound = camBounds.bounds;

        fireRate = 0.2f;
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
            if(!(transform.position.x == bound.max.x)  && !(transform.position.x == bound.min.x))
            this.transform.position += Vector3.right * side;
        }
        shoot();
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
