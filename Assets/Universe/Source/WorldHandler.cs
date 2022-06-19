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
    public Vector3 OldPlayerPosition;


    // Start is called before the first frame update
    void Start()
    {
        test = 1;

        this.SetFile();
        this.SetPlayerPosition();
        this.OldPlayerPosition = this.PlayerPosition;
        this.SpawnFloor(this.OldPlayerPosition);
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

    void SpawnFloor(Vector3 PlayerPositionToRender)
    {
        // calck starting Position
        float xStart = PlayerPositionToRender.x - 50.0f;
        float zStart = PlayerPositionToRender.z - 50.0f;


        Vector3 myVector;


        for (float xAxisFloat = xStart; xAxisFloat < xStart + 100; xAxisFloat = xAxisFloat + 10)
        {
            

            for (float zAxisFloat = zStart; zAxisFloat < zStart + 100; zAxisFloat = zAxisFloat + 10)
            {

                myVector = new Vector3(xAxisFloat, 0.0f, zAxisFloat);
                Instantiate(Floor, myVector, gameObject.transform.rotation);

            }
        }

        spawnerDone = true;

    }


    // Update is called once per frame
    void Update()
    {
        SetPlayerPosition();
        //checken in welche richtung sich bewegt wird, und neu render funktion triggern
        if(PlayerPosition.x)
    }
}
