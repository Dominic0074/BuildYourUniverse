using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerUniverse : MonoBehaviour
{

    public static void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
