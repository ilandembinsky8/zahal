using System;
using System.Text;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

public class LastKinObject : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro fullNameText;
    [SerializeField] private Button SearchButton;

    private SearchManager searchManager;
    private Casualty lastKinCasualtyData;
    
    private string nameToSearch;

    public void Init(Casualty lastKinCasualtyData)
    {
        searchManager = new();
        this.lastKinCasualtyData = lastKinCasualtyData;

        UpdateText();
        SearchButton.onClick.AddListener(SearchMe);
    }

    private void UpdateText()
    {
        StringBuilder strBuilder = new StringBuilder();

        if (!string.IsNullOrEmpty(lastKinCasualtyData.FirstName))
        {
            strBuilder.Append(lastKinCasualtyData.FirstName + " ");
        }
        
        if (!string.IsNullOrEmpty(lastKinCasualtyData.FirstName2))
        {
            strBuilder.Append(lastKinCasualtyData.FirstName2 + " ");
        }
        
        if (!string.IsNullOrEmpty(lastKinCasualtyData.NickName))
        {
            strBuilder.Append($"({lastKinCasualtyData.NickName}) ");
        }
        
        if (!string.IsNullOrEmpty(lastKinCasualtyData.LastName))
        {
            strBuilder.Append(lastKinCasualtyData.LastName + " ");
        }
        
        if (!string.IsNullOrEmpty(lastKinCasualtyData.LastName2))
        {
            strBuilder.Append(lastKinCasualtyData.LastName2 + " ");
        }

        fullNameText.text = strBuilder.ToString();
        nameToSearch = strBuilder.ToString();
    }

    private void SearchMe()
    {
        searchManager.LastKinFullNameSearch(nameToSearch);
    }

    private void OnDisable()
    {
        SearchButton.onClick.RemoveAllListeners();
    }
}