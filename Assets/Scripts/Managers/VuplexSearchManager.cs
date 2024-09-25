using System.Threading.Tasks;
using UnityEngine;
using Vuplex.WebView;

public class VuplexSearchManager : BaseSearchManager
{
    private CanvasWebViewPrefab webViewPrefab;
    private StringEventChannel eventChannel;
    
    private IWebView webView;

    public void Init(CanvasWebViewPrefab webViewPrefab, StringEventChannel eventChannel)
    {
        this.webViewPrefab = webViewPrefab;
        this.eventChannel = eventChannel;
        
        this.eventChannel.RegisterEvent(s => LastKinFullNameSearch(s));
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