using System;
using System.Text;
using UnityEngine;
using Vuplex.WebView;

public class SearchManager : BaseSearchManager
{
    public override void FullNameSearch(string fullNameString)
    {
        Application.OpenURL(FullNameURLStringMaker(WWW.EscapeURL(fullNameString)));
    }

    public override void LastKinFullNameSearch(string fullNameString)
    {
        Application.OpenURL(LastKinFullNameStringMaker(WWW.EscapeURL(fullNameString)));
    }
}