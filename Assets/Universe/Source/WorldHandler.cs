using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;



public class WorldHandler : MonoBehaviour
{

    public GameObject Floor;
    public GameObject[][] LoadedChuncks;

    // save Game vars
    private BinaryFormatter formatter;
    private FileStream file;
    public string filestatus;

    // Player Position
    public Vector3 PlayerPosition;
    public Vector3 OldPlayerPosition;
    public Vector3 RoundetPlayerPosition;

    // Start is called before the first frame update

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
        
    }

    void SpawnFloor(Vector3 PlayerPositionToRender)
    {
        // calck starting Position
        float xStart = PlayerPositionToRender.x - 50.0f;
        float zStart = PlayerPositionToRender.z - 50.0f;
        int x = 0, z = 0;

        Vector3 myVector;


        for (float xAxisFloat = xStart; xAxisFloat < xStart + 100; xAxisFloat = xAxisFloat + 10)
        {
            

            for (float zAxisFloat = zStart; zAxisFloat < zStart + 100; zAxisFloat = zAxisFloat + 10)
            {
                 

                myVector = new Vector3(xAxisFloat, 0.0f, zAxisFloat);
                LoadedChuncks[x][z] = Instantiate(Floor, myVector, gameObject.transform.rotation);
                z++;
            }

            x++;
        }


    }

    Vector3 RoundPlayerPosition()
    {
        //round x
        int Xround = (int)this.PlayerPosition.x / 10;
        int Zround = (int)this.PlayerPosition.z / 10;

        Xround = Xround * 10;
        Zround = Zround * 10;

        Vector3 roundetpos = new Vector3(Xround, 0.0f, Zround);

        return roundetpos;
    }


    void Start()
    {

        this.SetFile();
        this.SetPlayerPosition();
        this.OldPlayerPosition = RoundPlayerPosition();
        this.SpawnFloor(this.OldPlayerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerPosition();
        this.RoundetPlayerPosition = RoundPlayerPosition();
        //checken in welche richtung sich bewegt wird, und neu render funktion triggern
        if (RoundetPlayerPosition.x- OldPlayerPosition.x > 10 )
        {
            for (int x = 0; x < 10; x++)
            {
                for (int z = 0; z < 10; z++)
                {

                }
            }
        }
        else if (RoundetPlayerPosition.x- OldPlayerPosition.x < -10 )
        {

        }
        else if (RoundetPlayerPosition.z- OldPlayerPosition.z > 10 )
        {

        }
        else if (RoundetPlayerPosition.z- OldPlayerPosition.z < -10 )
        {

        }
    }
}
