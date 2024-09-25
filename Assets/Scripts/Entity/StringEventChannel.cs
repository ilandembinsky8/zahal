using System;
using UnityEngine;

[CreateAssetMenu(menuName = "String Event Channel")]
public class StringEventChannel : ScriptableObject
{
    public event Action<string> eventChannel;

    public void Raise(string s)
    {
        eventChannel?.Invoke(s);
    }

    public void RegisterEvent(Action<string> toRegister)
    {
        eventChannel += toRegister;
    }

    public void UnregisterEvent(Action<string> toUnregister)
    {
        eventChannel -= toUnregister;
    }
}