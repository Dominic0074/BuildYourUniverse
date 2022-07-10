using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public bool IsRespawning = false;
    public int Respawns=0;
    public int MaxRespawns; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Respawns > MaxRespawns)
        {
            Respawns = 0;
            IsRespawning = false;
        }

    }
}
