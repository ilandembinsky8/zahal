using System.Threading.Tasks;
using UnityEngine;
using Vuplex.WebView;

public class VuplexSearchManager : BaseSearchManager
{
    [SerializeField] private CanvasWebViewPrefab webViewPrefab;
    private IWebView webView;

    public void Init(CanvasWebViewPrefab webViewPrefab)
    {
        this.webViewPrefab = webViewPrefab;
    }

    public override void FullNameSearch(string fullNameString)
    {
        WaitIntilInit(FullNameURLStringMaker(WWW.EscapeURL(fullNameString)));
    }

    public override void LastKinFullNameSearch(string fullNameString)
    {
        WaitIntilInit(LastKinFullNameStringMaker(WWW.EscapeURL(fullNameString)));
    }

    public async Task WaitIntilInit(string escapeURL)
    {
        webViewPrefab.InitialUrl = escapeURL;
        await webViewPrefab.WaitUntilInitialized();
        webViewPrefab.WebView.LoadUrl(escapeURL);
    }
}