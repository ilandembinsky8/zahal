using System;
using System.Text;
using UnityEngine;

public class SearchManager
{
    const string IZKOR_HOMEPAGE = "https://www.izkor.gov.il\\";
    const string SEARCH_PREFIX = "searchforMemoryCandle\\";
    const string EXTENDED_SEARCH = "extended-search";
    const string LAST_KIN_FIX = "&is_last_of_kin=true";
    private const string FULL_NAME_PREFIX = "?full_name=";
    
    private static string FullNameSearchPrefix => IZKOR_HOMEPAGE + SEARCH_PREFIX;
    private static string LastKinFullNameSearchPrefix => FullNameSearchPrefix + EXTENDED_SEARCH;

    public void FullNameSearch(string fullNameString)
    {
        Application.OpenURL(FullNameURLStringMaker(WWW.EscapeURL(fullNameString)));
    }
    
    private string FullNameURLStringMaker(string processedString)
    {
        Debug.Log($"{FullNameSearchPrefix}{processedString}{FULL_NAME_PREFIX}{processedString}");
        return $"{FullNameSearchPrefix}{processedString}{FULL_NAME_PREFIX}{processedString}";
    }

    public void LastKinFullNameSearch(string fullNameString)
    {
        Application.OpenURL(LastKinFullNameStringMaker(WWW.EscapeURL(fullNameString)));
    }

    private string LastKinFullNameStringMaker(string processedString)
    {
        Debug.Log($"{LastKinFullNameSearchPrefix}{FULL_NAME_PREFIX}{processedString}{LAST_KIN_FIX}");
        return $"{LastKinFullNameSearchPrefix}{FULL_NAME_PREFIX}{processedString}{LAST_KIN_FIX}";
    }
}