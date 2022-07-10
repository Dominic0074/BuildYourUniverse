using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public static bool Hit = false;
    void Start()
    {
        
    }
    
   public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            Hit = true; 
            
            
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
