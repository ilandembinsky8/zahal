using System;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vuplex.WebView;

public class IzkorSearch : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro firstNameInput;
    [SerializeField] private RTLTextMeshPro lastNameInput;
    [SerializeField] private Button searchButton;
    [SerializeField] private CanvasWebViewPrefab canvasWebViewPrefab;
    [SerializeField] private StringEventChannel izokrEventChannel;
    [SerializeField] private TMP_InputField firstInput;
    [SerializeField] private TMP_InputField lastInput;
    
    [Header("Go References")] 
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SearchMenu;
    [SerializeField] private GameObject VuplexWebView;
    [SerializeField] private GameObject VuplexPageRenderer;
    [SerializeField] private GameObject VuplexPageRenderer2;
    
    private VuplexSearchManager searchManager;
    
    private const float TIME_THRESHOLD = 80f;
    private bool canIdle;
    private float elapsedTimer = 0;
    
    private void Awake()
    {
        searchManager = new ();
        searchManager.InitIzkor(izokrEventChannel,canvasWebViewPrefab);
    }

    private void OnEnable()
    {
        izokrEventChannel.RegisterEvent(s => EnableWebView());
        searchButton.onClick.AddListener(OnSearchButtonClicked);
        searchManager.PageLoaded += ToggleVuplexRenderers;
    }

    private void ToggleVuplexRenderers()
    {
        VuplexPageRenderer.SetActive(!VuplexPageRenderer.activeInHierarchy);
        VuplexPageRenderer2.SetActive(!VuplexPageRenderer2.activeInHierarchy);
    }
    
    private void ToggleVuplexRenderers(bool isActive)
    {
        VuplexPageRenderer.SetActive(isActive);
        VuplexPageRenderer2.SetActive(isActive);
    }

    private void OnSearchButtonClicked()
    {
        izokrEventChannel.Raise($"{firstNameInput.text} {lastNameInput.text}");
    }

    private void OnDisable()
    {
        searchButton.onClick.RemoveAllListeners();
    }

    #region GameObjectActivation
    
    public void EnableWebView()
    {
        canIdle = true;
        VuplexWebView.SetActive(true);
        MainMenu.SetActive(true);
        SearchMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        canIdle = false;
        ToggleVuplexRenderers(false);
        firstInput.text = string.Empty;
        lastInput.text = string.Empty;
        MainMenu.SetActive(true);
        VuplexWebView.SetActive(false);
        SearchMenu.SetActive(false);
    }

    public void EnableSearch()
    {
        canIdle = true;
        MainMenu.SetActive(false);
        VuplexWebView.SetActive(false);
        SearchMenu.SetActive(true);
    }
    
    #endregion
    
    #region Idle

    private void Update()
    {
        if (canIdle)
        {
            elapsedTimer += Time.deltaTime;
            
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
            {
                ResetClock();
            }

            if (elapsedTimer >= TIME_THRESHOLD)
            {
                canIdle = false;
                ResetClock();
                ReturnToMainMenu();
            }
        }
    }

    private void ResetClock()
    {
        elapsedTimer = 0;
    }

    #endregion
}