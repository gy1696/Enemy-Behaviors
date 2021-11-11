using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHeroScript : MonoBehaviour
{
    public EnemySpawnControl e;
    // Start is called before the first frame update
    void Start()
    {

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
