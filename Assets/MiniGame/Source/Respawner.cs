using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public bool IsRespawning = false;
    public int Respawns=0;
    public int MaxRespawns;
    public TriggerEvent PointObject; 
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

            int Currency = PlayerPrefs.GetInt("Currency")+PointObject.points;
            PlayerPrefs.SetInt("Currency", Currency);
            PlayerPrefs.Save();         
            Debug.Log("Currency: " + Currency);
            Debug.Log("Punkte: " + PointObject.points);
            PointObject.points = 0;

        }

    }
}
