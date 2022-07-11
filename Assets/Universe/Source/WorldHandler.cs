using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;



public class WorldHandler : MonoBehaviour
{
    
    public GameObject Floor;

    public GameObject[] PlacableObjects;

    //player position
    public Vector3 PlayerPosition;

    void Start()
    {
        //PlayerPrefs.SetInt("ObjectCount", 0);
        //PlayerPrefs.Save();
        if (!PlayerPrefs.HasKey("ObjectCount"))
        {
            PlayerPrefs.SetInt("ObjectCount", 0);
        }

        this.SetPlayerPosition();
        this.SpawnFloor(this.PlayerPosition);

        if (!Directory.Exists(Application.persistentDataPath + "/Objects"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Objects");
        }

        this.SpawnSavedObjects();
        
        
    }

    // Spawn all Saved Objects

    void SpawnSavedObjects()
    {
        string path = Application.persistentDataPath + "/Objects";

        System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo(path);



        foreach (System.IO.FileInfo f in ParentDirectory.GetFiles())
        {
            SaveHandler Saver = new SaveHandler();
            

            SaveData data = new SaveData();
            data = Saver.LoadSingleObject(f.Name);
            Vector3 position = new Vector3(data.positionX, data.positionY, data.positionZ);
            Quaternion rotation = new Quaternion(data.rotationX, data.rotationY, data.rotationZ,0.0f);
            Vector3 scale = new Vector3(data.scaleX, data.scaleY, data.scaleZ);
            int objNr = 0;
            for (int key = 0; key < PlacableObjects.Length; ++key)
            {
                if (PlacableObjects[key].name == data.ObjectName)
                {
                    GameObject latestSpawn = Instantiate(PlacableObjects[key],position, rotation );
                    latestSpawn.transform.localScale = scale; 

                }
                    
            }

            

            
            Debug.Log("Datei: " + f.Name);
        }
        
    }


    // Set Player Position 
    void SetPlayerPosition()
    {
        Camera m_MainCamera;
        //This gets the Main Camera from the Scene
        m_MainCamera = Camera.main;
        //This enables Main Camera
        m_MainCamera.enabled = true;

        PlayerPosition = m_MainCamera.transform.position;

    }

    
    //Load 1 chunk
    void LoadChunk (int xArray, int zArray, Vector3 Vector)
    {
        Instantiate(this.Floor, Vector, gameObject.transform.rotation);
    }


    //spawns initial the floor arount the player
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
                LoadChunk(x,z, myVector);
                z++;
               
            }

            x++;
        }


    }
    


 
    // Update is called once per frame
    void Update()
    {

    }


}