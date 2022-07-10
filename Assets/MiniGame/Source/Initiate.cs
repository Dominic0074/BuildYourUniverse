using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Currency"))
        {
            PlayerPrefs.SetInt("Currency", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
