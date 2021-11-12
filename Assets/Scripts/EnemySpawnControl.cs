using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControl : MonoBehaviour
{
    GameObject spawn;
    // Start is called before the first frame update
    public void SpawnUFO()
    {
        Instantiate(Resources.Load("Prefabs/UFO"), new Vector3(-40, 150, 0), Quaternion.Euler(new Vector3(0,0,0))); 
        Instantiate(Resources.Load("Prefabs/UFO"), new Vector3(40, 150, 0), Quaternion.Euler(new Vector3(0,0,0))); 
    }

    public void SpawnFighter()
    {
        Instantiate(Resources.Load("Prefabs/Fighter"), new Vector3(0, 150, 0), Quaternion.Euler(new Vector3(0,0,0))); 
        Instantiate(Resources.Load("Prefabs/Fighter"), new Vector3(-50, 150, 0), Quaternion.Euler(new Vector3(0,0,0))); 
        Instantiate(Resources.Load("Prefabs/Fighter"), new Vector3(100, 150, 0), Quaternion.Euler(new Vector3(0,0,-45))); 
    }

    public void SpawnChaser()
    {
        Instantiate(Resources.Load("Prefabs/Chaser"), new Vector3(0, 150, 0), Quaternion.Euler(new Vector3(0,0,0))); 
    }
}
