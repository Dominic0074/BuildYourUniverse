using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    private SaveHandler Saver;

    public string filename;

    // Start is called before the first frame update
    void Start()
    {
        filename = transform.name;
        Debug.Log("Objectname :" + filename);
    }

    // Update is called once per frame
    void Update()
    {
        Saver = FindObjectOfType<SaveHandler>();
        if(Saver.SaveAllObjects)
        {
            
            Saver.SaveSingleObject(transform.position, transform.rotation, transform.localScale, filename);
            Saver.SavedObjectCount++;
        }
    }
}
