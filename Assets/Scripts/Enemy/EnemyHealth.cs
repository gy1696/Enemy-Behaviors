using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health;
    int bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void setHealth(int h, int lvl)
    {
        health = h * lvl;
    }

    public void decreaseHealth()
    {
        health--;
    }
}
