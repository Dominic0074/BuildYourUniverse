using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cans : MonoBehaviour
{
    public Respawner Respawner1; 
    // save the cans original Position
    public Vector3 CanPosition;
    // save the cans original Rotation
    public Quaternion CanRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        CanPosition = transform.position;
        CanRotation = transform.rotation;
    }



   public void Reposition()
    {
        transform.position = CanPosition;
        transform.rotation = CanRotation;
        Respawner1.Respawns++;
    }
    // Update is called once per frame
    void Update()
    {
        if (Respawner1.IsRespawning == true)
        {
            Reposition();
        }
    }
}
