using System.Runtime.CompilerServices;
using UnityEngine;

public static class LogHelper
{
    public static void Log(string message, Object context = null, [CallerMemberName] string caller = "")
    {
        Debug.Log($"[{caller}] {message}", context);
    }

    public static void LogWarning(string message, Object context = null, [CallerMemberName] string caller = "")
    {
        Debug.LogWarning($"[{caller}] {message}", context);
    }

    public static void LogError(string message, Object context = null, [CallerMemberName] string caller = "")
    {
        Debug.LogError($"[{caller}] {message}", context);
    }
}
