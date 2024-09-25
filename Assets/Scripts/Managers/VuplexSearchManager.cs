using System.Threading.Tasks;
using UnityEngine;
using Vuplex.WebView;

public class VuplexSearchManager : BaseSearchManager
{
    private CanvasWebViewPrefab webViewPrefab;
    private StringEventChannel lastKinEventChannel;
    private StringEventChannel izkorEventChannel;
    
    private IWebView webView;

    public void InitLastKin(CanvasWebViewPrefab webViewPrefab, StringEventChannel lastKinEventChannel)
    {
        this.webViewPrefab = webViewPrefab;
        this.lastKinEventChannel = lastKinEventChannel;
        
        this.lastKinEventChannel.RegisterEvent(s => LastKinFullNameSearch(s));
    }
    
    public void InitIzkor(StringEventChannel izkorEventChannel, CanvasWebViewPrefab webViewPrefab)
    {
        this.webViewPrefab = webViewPrefab;
        this.izkorEventChannel = izkorEventChannel;
        
        this.izkorEventChannel.RegisterEvent(s => FullNameSearch(s));
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