using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;
using Vuplex.WebView;

public class LastKinSearch : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro firstNameInput;
    [SerializeField] private RTLTextMeshPro lastNameInput;
    [SerializeField] private Button searchButton;
    [SerializeField] private CanvasWebViewPrefab webViewPrefab;
    
    private VuplexSearchManager searchManager;
    
    private void Awake()
    {
        searchManager = new ();
        searchManager.Init(webViewPrefab);
    }

    private void OnEnable()
    {
        searchButton.onClick.AddListener(() => webViewPrefab.transform.parent.gameObject.SetActive(true));
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