using UnityEngine;

public class BaseSearchManager : ISearchManager
{
    protected const string IZKOR_HOMEPAGE = "https://www.izkor.gov.il\\";
    protected const string SEARCH_PREFIX = "searchforMemoryCandle\\";
    protected const string EXTENDED_SEARCH = "extended-search";
    protected const string LAST_KIN_FIX = "&is_last_of_kin=true";
    protected const string FULL_NAME_PREFIX = "?full_name=";
    
    protected static string FullNameSearchPrefix => IZKOR_HOMEPAGE + SEARCH_PREFIX;
    protected static string LastKinFullNameSearchPrefix => FullNameSearchPrefix + EXTENDED_SEARCH;
    
    public virtual void FullNameSearch(string fullNameString)
    {
        // NOOP
    }

    public virtual void LastKinFullNameSearch(string fullNameString)
    {
        // NOOp
    }
    
    protected string FullNameURLStringMaker(string processedString)
    {
        Debug.Log($"{FullNameSearchPrefix}{processedString}{FULL_NAME_PREFIX}{processedString}");
        return $"{FullNameSearchPrefix}{processedString}{FULL_NAME_PREFIX}{processedString}";
    }
    
    protected string LastKinFullNameStringMaker(string processedString)
    {
        Debug.Log($"{LastKinFullNameSearchPrefix}{FULL_NAME_PREFIX}{processedString}{LAST_KIN_FIX}");
        return $"{LastKinFullNameSearchPrefix}{FULL_NAME_PREFIX}{processedString}{LAST_KIN_FIX}";
    }
}