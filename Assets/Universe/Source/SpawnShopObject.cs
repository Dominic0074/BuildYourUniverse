using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

public class SpawnShopObject : MonoBehaviour
{
    public Transform itemSpawn;
    public GameObject shopObject;
    int ObjectCount;


    public void SpawnShopObjects()
    {
        Instanciate();

    }

    void Instanciate()
    {
           GameObject NewObject = Instantiate(shopObject, itemSpawn.position, itemSpawn.rotation);
        

        ObjectCount = PlayerPrefs.GetInt("ObjectCount");
        ObjectCount++;
        NewObject.name ="Object"+ ObjectCount;
        PlayerPrefs.SetInt("ObjectCount", ObjectCount);
        PlayerPrefs.Save();

        SaveHandler Saving = FindObjectOfType<SaveHandler>();
        Saving.SaveNewObject(itemSpawn.position, itemSpawn.rotation, itemSpawn.localScale, ObjectCount, shopObject.name);
    }



}

