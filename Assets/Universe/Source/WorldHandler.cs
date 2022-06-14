using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;



public class WorldHandler : MonoBehaviour
{

    GameObject currentPoint;

    public GameObject Floor;
    public int test;
    public bool spawnerDone;
    
    public string filestatus;

    // save Game vars
    private BinaryFormatter formatter;
    private FileStream file;

    // Player Position
    public Vector3 PlayerPosition;


    // Start is called before the first frame update
    void Start()
    {
        test = 1;

        Invoke("SpawnFloor", 0.0f);
        this.SetFile();
    }

    void SetFile()
    {
        if (File.Exists(Application.persistentDataPath
               + "/MySaveData.dat"))
        {
            this.file = File.Open(Application.persistentDataPath
                       + "/MySaveData.dat", FileMode.Open);
            filestatus = "exist";
        }
        else
        {
            this.file = File.Create(Application.persistentDataPath
                         + "/MySaveData.dat");
            filestatus = "created";
        }

        this.formatter = new BinaryFormatter();
    }

    void SetPlayerPosition()
    {
        Camera m_MainCamera;
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
        //This enables Main Camera
        m_MainCamera.enabled = true;

        PlayerPosition = m_MainCamera.transform.position;
        
        Debug.Log(m_MainCamera.transform.position);
    }

    void SpawnFloor()
    {
        // calck starting Position
        float xStart = PlayerPosition.x;
        float zStart = PlayerPosition.z;


        Vector3 myVector;


        for (float xAxisInt = 0; xAxisInt < 10; xAxisInt++)
        {
            float xAxisFloat = (float)xAxisInt * 10;

            for (float zAxisInt = 0; zAxisInt < 10; zAxisInt++)
            {
                float zAxisFloat = (float)zAxisInt * 10;
                myVector = new Vector3(xAxisFloat, 0.0f, zAxisFloat);
                Instantiate(Floor, myVector, gameObject.transform.rotation);

            }
        }

        spawnerDone = true;

    }


    // Update is called once per frame
    void Update()
    {

    }
}
