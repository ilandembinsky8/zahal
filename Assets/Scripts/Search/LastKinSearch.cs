using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vuplex.WebView;

public class LastKinSearch : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro firstNameInput;
    [SerializeField] private RTLTextMeshPro lastNameInput;
    [SerializeField] private Button searchButton;
    [SerializeField] private CanvasWebViewPrefab webViewPrefab;
    [SerializeField] private StringEventChannel lastKinEventChannel;

    [Header("Go References")] 
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SearchMenu;
    [SerializeField] private GameObject ListMenu;
    [SerializeField] private GameObject VuplexWebView;
    
    private VuplexSearchManager searchManager;

    private TMP_InputField first;
    private TMP_InputField last;
    private void Awake()
    {
        searchManager = new ();
        searchManager.Init(webViewPrefab,lastKinEventChannel);
    }

    private void OnEnable()
    {
        lastKinEventChannel.RegisterEvent(s => EnableWebView());
        searchButton.onClick.AddListener(OnSearchButtonClick);
    }
    
    private void OnSearchButtonClick()
    {
        lastKinEventChannel.Raise($"{firstNameInput.text} {lastNameInput.text}");
        // searchManager.LastKinFullNameSearch($"{firstNameInput.text} {lastNameInput.text}");
    }

    private void OnDisable()
    {
        searchButton.onClick.RemoveAllListeners();
    }
    
    #region GameObjectActivation
    
    public void EnableWebView()
    {
        VuplexWebView.SetActive(true);
        MainMenu.SetActive(true);
        SearchMenu.SetActive(false);
        ListMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        MainMenu.SetActive(true);
        VuplexWebView.SetActive(false);
        SearchMenu.SetActive(false);
        ListMenu.SetActive(false);
    }

    public void EnableSearch()
    {
        MainMenu.SetActive(false);
        VuplexWebView.SetActive(false);
        SearchMenu.SetActive(true);
        ListMenu.SetActive(false);
    }

    public void EnableList()
    {
        MainMenu.SetActive(false);
        VuplexWebView.SetActive(false);
        SearchMenu.SetActive(false);
        ListMenu.SetActive(true);
    }
    
    #endregion
}