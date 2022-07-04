using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coderesteworldhandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        SetPlayerPosition();
        this.RoundetPlayerPosition = RoundPlayerPosition();


        //checken in welche richtung sich bewegt wird, und neu render funktion triggern
        if (RoundetPlayerPosition.x - OldPlayerPosition.x > 10)
        {
            MoovePosX(this.RoundetPlayerPosition);
        }
        else if (RoundetPlayerPosition.x - OldPlayerPosition.x < -10)
        {
            MooveNegX(this.RoundetPlayerPosition);
        }
        else if (RoundetPlayerPosition.z - OldPlayerPosition.z > 10)
        {
            MoovePosZ(this.RoundetPlayerPosition);
        }
        else if (RoundetPlayerPosition.z - OldPlayerPosition.z < -10)
        {
            MooveNegZ(this.RoundetPlayerPosition);
        }
        */

    }
}

/*
// Round Player Position to get the begin of the actual Chunk
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

*/

/*
void DestroyChunk (int xAxis, int zAxis)
{
    Destroy(LoadedChuncks[xAxis][zAxis]);
}
*/


/*
    // moove rendert field in Positiv x coordinate
    void MoovePosX(Vector3 PlayerPositionToRender)
    {
        float xStart = PlayerPositionToRender.x - 50.0f;
        float zStart = PlayerPositionToRender.z - 50.0f;

        Vector3 myVector;

        for (int xAxis = 0; xAxis <10; xAxis++ )
        {
            for (int zAxis = 0; zAxis < 10; zAxis++)
            {
                if(xAxis == 0)
                {

                    DestroyChunk(xAxis, zAxis);
                }
                else if (xAxis == 9)
                {
                    myVector = new Vector3(xStart, 0.0f, zStart);
                    LoadChunk(xAxis, zAxis, myVector);
                }
                else
                {
                    LoadedChuncks[xAxis][zAxis] = LoadedChuncks[xAxis + 1][zAxis];

                }
                zStart = zStart + 10.0f;
            }
            xStart = xStart + 10.0f;
        }
            
    }

    // moove rendert field in Negativ x coordinate
    void MooveNegX(Vector3 PlayerPositionToRender)
    {
        float xStart = PlayerPositionToRender.x + 50.0f;
        float zStart = PlayerPositionToRender.z + 50.0f;

        Vector3 myVector;

        for (int xAxis = 9; xAxis >= 0; xAxis--)
        {
            for (int zAxis = 0; zAxis < 10; zAxis++)
            {
                if (xAxis == 9)
                {

                    DestroyChunk(xAxis, zAxis);
                }
                else if (xAxis == 0)
                {
                    myVector = new Vector3(xStart, 0.0f, zStart);
                    LoadChunk(xAxis, zAxis, myVector);
                }
                else
                {
                    LoadedChuncks[xAxis][zAxis] = LoadedChuncks[xAxis + 1][zAxis];

                }
                zStart = zStart - 10.0f;
            }
            xStart = xStart - 10.0f;
        }

    }

    // moove rendert field in Positiv x coordinate
    void MoovePosZ(Vector3 PlayerPositionToRender)
    {
        float xStart = PlayerPositionToRender.x - 50.0f;
        float zStart = PlayerPositionToRender.z - 50.0f;

        Vector3 myVector;

        for (int zAxis = 0; zAxis < 10; zAxis++)
        {
            for (int xAxis = 0; xAxis < 10; xAxis++)
            {
                if (xAxis == 0)
                {

                    DestroyChunk(xAxis, zAxis);
                }
                else if (xAxis == 9)
                {
                    myVector = new Vector3(xStart, 0.0f, zStart);
                    LoadChunk(xAxis, zAxis, myVector);
                }
                else
                {
                    LoadedChuncks[xAxis][zAxis] = LoadedChuncks[xAxis + 1][zAxis];

                }
                zStart = zStart + 10.0f;
            }
            xStart = xStart + 10.0f;
        }

    }

    // moove rendert field in Negativ x coordinate
    void MooveNegZ(Vector3 PlayerPositionToRender)
    {
        float xStart = PlayerPositionToRender.x + 50.0f;
        float zStart = PlayerPositionToRender.z + 50.0f;

        Vector3 myVector;

        for (int zAxis = 9; zAxis >= 0; zAxis--)
        {
            for (int xAxis = 0; xAxis < 10; xAxis++)
            {
                if (xAxis == 9)
                {

                    DestroyChunk(xAxis, zAxis);
                }
                else if (xAxis == 0)
                {
                    myVector = new Vector3(xStart, 0.0f, zStart);
                    LoadChunk(xAxis, zAxis, myVector);
                }
                else
                {
                    LoadedChuncks[xAxis][zAxis] = LoadedChuncks[xAxis + 1][zAxis];

                }
                zStart = zStart - 10.0f;
            }
            xStart = xStart - 10.0f;
        }

    }
    */