using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveHandler : MonoBehaviour
{

    public bool SaveAllObjects = false;
    public int SavedObjectCount = 0;
    public int ObjectsToSave;


    SaveData data = new SaveData();
    private string path = "";
    private string persistentPath = "";


    public void SaveNewObject(Vector3 position, Quaternion rotation, Vector3 scale, int ObjectCount, string Objectname)
    {
        CreatePlayerData(position, rotation,  scale, Objectname);
        SetPaths(ObjectCount);
        SaveData();
        LoadData();
    }

    public void SaveSingleObject(Vector3 position, Quaternion rotation, Vector3 scale, string filename)
    {
        SetPaths(filename);
        
        string name = LoadData().ObjectName;
        CreatePlayerData(position, rotation, scale, name);
        SaveData();
        
    }

    public SaveData LoadSingleObject (string datei)
    {
        SetPathswithDatei(datei);

        return LoadData();
    }
    
        // Start is called before the first frame update
    void Start()
    {
        ObjectsToSave = PlayerPrefs.GetInt("ObjectCount");
    }

    // Update is called once per frame
    void Update()
    {
        if(SavedObjectCount > ObjectsToSave)
        {
            SaveAllObjects = false; 
            SavedObjectCount = 0;
        }
    }
    private void SetPaths(int ObjectCount)
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "Objects"+ Path.AltDirectorySeparatorChar+ "Object"+ ObjectCount + ".json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "Objects" + Path.AltDirectorySeparatorChar + "Object" + ObjectCount + ".json";
    }

    private void SetPathswithDatei(string ObjectCount)
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "Objects" + Path.AltDirectorySeparatorChar + ObjectCount;
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "Objects" + Path.AltDirectorySeparatorChar + ObjectCount;
    }

    private void SetPaths(string ObjectCount)
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "Objects" + Path.AltDirectorySeparatorChar + ObjectCount + ".json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "Objects" + Path.AltDirectorySeparatorChar + ObjectCount + ".json";
    }

    private void CreatePlayerData(Vector3 position, Quaternion rotation, Vector3 scale, string ObjectName)
    {
        //set position

        data.positionX = position.x;
        data.positionY = position.y;
        data.positionZ = position.z;

        //set rotation
        data.rotationX = rotation.x;
        data.rotationY = rotation.y;
        data.rotationZ = rotation.z;

        //set Scale

        data.scaleX = scale.x;
        data.scaleY = scale.y;
        data.scaleZ = scale.z;

        data.ObjectName = ObjectName;
    }

    public void SaveData()
    {
        string savePath = persistentPath;

        Debug.Log("Saving Data at " + savePath);
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public SaveData LoadData()
    {
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();

        SaveData data2 = JsonUtility.FromJson<SaveData>(json);

        return data2;
    }
}

public class SaveData
{
    public float positionX, positionY, positionZ,
                    rotationX, rotationY, rotationZ,
                    scaleX, scaleY, scaleZ;
    public string ObjectName;
}