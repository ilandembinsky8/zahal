using System;
using System.Threading.Tasks;
using UnityEngine;
using Vuplex.WebView;

public class VuplexSearchManager : BaseSearchManager
{
    public event Action PageLoaded;
    
    private CanvasWebViewPrefab webViewPrefab;
    private StringEventChannel lastKinEventChannel;
    private StringEventChannel izkorEventChannel;
    
    private IWebView webView;

    private bool isInit;
    private bool isLoaded;
    
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
        Debug.Log("Initialized");
        webViewPrefab.WebView.LoadUrl(escapeURL);
        await webViewPrefab.WebView.WaitForNextPageLoadToFinish();
        Debug.Log("PageLoaded");
        PageLoaded?.Invoke();
    }
}