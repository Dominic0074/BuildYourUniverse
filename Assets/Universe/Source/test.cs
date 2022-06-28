using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;



public class WorldHandler1 : MonoBehaviour
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

    void checkfile(int Xcoord, int Zcoord)
    {
        if (File.Exists(Application.persistentDataPath
                + "/" + Xcoord + Zcoord + ".dat"))
        {
            this.file = File.Open(Application.persistentDataPath
                       + "/" + Xcoord + Zcoord + ".dat", FileMode.Open);
            filestatus = "exist";
        }
        else
        {
            this.file = File.Create(Application.persistentDataPath
                         + "/" + Xcoord + Zcoord + ".dat");
            filestatus = "created";
        }

        this.formatter = new BinaryFormatter();
    }

    FileStream getFile()
    {
        return this.file;
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
                // read file & spawn objects
                checkfile(x, z);
                foreach (string line in getFile())
                {
                    System.Console.WriteLine(line);
                    counter++;
                }
            }

            x++;
        }


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
        if (RoundetPlayerPosition.x - OldPlayerPosition.x > 10)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int z = 0; z < 10; z++)
                {

                }
            }
        }
        else if (RoundetPlayerPosition.x - OldPlayerPosition.x < -10)
        {

        }
        else if (RoundetPlayerPosition.z - OldPlayerPosition.z > 10)
        {

        }
        else if (RoundetPlayerPosition.z - OldPlayerPosition.z < -10)
        {

        }
    }
}
