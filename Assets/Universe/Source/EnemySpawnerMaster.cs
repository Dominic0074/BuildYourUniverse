using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMaster : MonoBehaviour
{

    GameObject currentPoint;
    int index;


    public GameObject[] Floor;

    public bool spawnerDone;



    // Start is called before the first frame update
    void Start()
    {

    
        Invoke("SpawnWorld", 0);
    }

    void SpawnWorld()
    {


        

        Vector3 myVector = new Vector3(0.0f, 0.0f, 0.0f);



        Instantiate(Floor[0], myVector , currentPoint.transform.rotation);

 
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
