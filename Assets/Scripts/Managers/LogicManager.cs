using System;
using System.Collections;
using System.Collections.Generic;
using CSV;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    [SerializeField] private List<Casualty> LastKinCasulaties;
    
    private CSVReader csvReader;
    private static string _csvLocation => Application.streamingAssetsPath + "\\LastKinList.csv";
    
    private void Start()
    {
        csvReader = new ();
        
        LastKinCasulaties = csvReader.ReadCSVFile(_csvLocation);
    }
    
    
}