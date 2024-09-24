using System;
using System.Text;
using UnityEngine;

public class SearchManager : MonoBehaviour
{
    const string IZKOR_HOMEPAGE = "https://www.izkor.gov.il\\";
    const string SEARCH_PREFIX = "searchforMemoryCandle\\";
    
    private static string FullNameSearchPrefix => IZKOR_HOMEPAGE + SEARCH_PREFIX;

    private void Start()
    {
        FullNameSearch("שלו חזן");
    }

    public void FullNameSearch(string fullNameString)
    {
        Application.OpenURL(FullNameStringBuilderUtility(WWW.EscapeURL(fullNameString)));
    }
    
    private string FullNameStringBuilderUtility(string processedString)
    {
        Debug.Log($"{FullNameSearchPrefix}{processedString}?full_name={processedString}");
        return $"{FullNameSearchPrefix}{processedString}?full_name={processedString}";
    }
}