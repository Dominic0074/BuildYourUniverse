using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerUniverse : MonoBehaviour
{

    public static void Load(int i)
    {
        SceneManager.LoadScene(i);
    }
}
