using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallCollision : MonoBehaviour
{   
    //save Ball Position
    public Vector3 BallPosition;
    //save Ball Rotation
    public Quaternion BallRotation;
    public Respawner Respawner1;
    // save the cans original Position
   
    // Start is called before the first frame update
    void Start()
    {
        // save the balls original Position
        BallPosition = transform.position;
        // save the balls original Rotation
        BallRotation = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {      
    }
    void Respawn()
    {
        Respawner1.IsRespawning = true;
        Reposition();
    }

    public void Reposition()
    {
        //stop the velocity of the ball
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        //stop the angular velocity of the ball
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //reset the position and rotation of the ball

        transform.position = BallPosition;
        transform.rotation = BallRotation;        
        Respawner1.Respawns++;    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Floor")
        {
            Debug.Log("Ball aufgekommen");
            Invoke("Respawn", 5);
            
        }
    }
}
