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
            return;
        }

        Debug.LogError("sceneConfig file are either is not found. or setup the wrong way." +
                       $"if it is not there, add a sceneConfig.txt into and make sure this path is compelte{SceneConfigPath}" +
                       $"if not. make sure the following format is applied to one of the lines:" +
                       $"'sceneIndex=sceneNumber=', the scene number can be either 1 or 2");
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
                        if (index == 1 || index == 2)
                        {
                            return index;
                        }
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
