using System;
using System.Collections;
using System.Collections.Generic;
using CSV;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    [SerializeField] private List<Casualty> LastKinCasulaties;
    [SerializeField] private GameObject LastKinBoxPrefab;
    
    private CSVReader csvReader;
    private static string _csvLocation => Application.streamingAssetsPath + "\\LastKinList.csv";
    
    private void Start()
    {
        csvReader = new ();
        
        LastKinCasulaties = csvReader.ReadCSVFile(_csvLocation);
        
        foreach (var lastKin in LastKinCasulaties)
        {
            GameObject go = Instantiate(LastKinBoxPrefab,transform);
            go.GetComponent<LastKinObject>().Init(lastKin);
        }
    }
}