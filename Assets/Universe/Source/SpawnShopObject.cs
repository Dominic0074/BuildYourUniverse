using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShopObject : MonoBehaviour
{
    public Transform itemSpawn;
    public GameObject shopObject;

    public void SpawnShopObjects()
    {
        Instanciate();
    }

    private void Instanciate()
    {
        Instantiate(shopObject,itemSpawn.position,itemSpawn.rotation);
    }
}
