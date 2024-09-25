using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    private static string SceneConfigPath => Application.streamingAssetsPath + "\\sceneConfig.txt";

    private void Start()
    {
        int index = GetSceneIndex();
        if (index != -1)
        {
            SceneManager.LoadScene(index);
        }
    }

    int GetSceneIndex()
    {
        if (File.Exists(SceneConfigPath))
        {
            string[] lines = File.ReadAllLines(SceneConfigPath);
            foreach (var line in lines)
            {
                if (line.StartsWith("sceneIndex"))
                {
                    string[] configLine = line.Split("=");
                    if (Int32.TryParse(configLine[1], out int index))
                    {
                        return index;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("config file not found!");
        }

        return -1;
    }
    
}
