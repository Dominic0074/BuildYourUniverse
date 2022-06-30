using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    int points = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // creates a triggerenter function
    void OnTriggerEnter(Collider other)
    {
        // if the other object is the player
        if (other.gameObject.tag == "Player")
        {
            points++;
            Debug.Log(points);
        }
    }
}
