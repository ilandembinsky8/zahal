﻿using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

public class LastKinSearch : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro firstNameInput;
    [SerializeField] private RTLTextMeshPro lastNameInput;
    [SerializeField] private Button searchButton;
    
    private SearchManager searchManager;
    
    private void Awake()
    {
        searchManager = new SearchManager();
    }

    private void OnEnable()
    {
        searchButton.onClick.AddListener(SearchButton);
    }

    private void OnDisable()
    {
        searchButton.onClick.RemoveAllListeners();
    }

    private void SearchButton()
    {
        searchManager.LastKinFullNameSearch($"{firstNameInput.text} {lastNameInput.text}");
    }
}