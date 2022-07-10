using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
    
{
    public Transform[] Spawnpoints;
    public GameObject Can;
    public float SpawnDelay = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate();
    }

    public void RespawnTriggered()
    {
        if (Collision.Hit == true)
        {
            Debug.Log("Boink");
            Collision.Hit = false;
            float delay = 0;
            while (delay<SpawnDelay)
            {
                (delay) += Time.deltaTime;
                if (delay >= SpawnDelay)
                {
                    
                    DestroyImmediate(Can, true);
                    Instantiate();
                    
                    
                }
                
            }
            
              
            
            delay = 0; 
        }
    }
    public void Instantiate()
    {
        for (int i = 0; i < Spawnpoints.Length; i++)
        {
            Instantiate(Can, Spawnpoints[i].position, Spawnpoints[i].rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RespawnTriggered();
    }
}
