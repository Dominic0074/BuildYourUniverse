using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;



public class WorldHandler : MonoBehaviour
{
    public GameObject Floor;

    //player position
    public Vector3 PlayerPosition;


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
    


    void Start()
    {

        
        this.SetPlayerPosition();
        this.SpawnFloor(this.PlayerPosition);
    }

    // Update is called once per frame
    void Update()
    {

    }


}