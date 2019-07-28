using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class CustomDebug 
{
    /// <summary>
    /// will log only in Unity editor
    /// </summary>
    [Conditional("UNITY_EDITOR")]
    public static void Log(string msg)
    {
        Debug.Log(msg);
    }

    /// <summary>
    /// will log warning only in Unity editor
    /// </summary>
    [Conditional("UNITY_EDITOR")]
    public static void LogWarning(string msg)
    {
        Debug.LogWarning(msg);
    }

    /// <summary>
    /// will log Error in Unity editor as well as in device
    /// </summary>
    public static void LogError(string msg)
    {
        Debug.LogError(msg);
    }

    /// <summary>
    /// will log Exception in Unity editor as well as in device
    /// </summary>
    public static void LogException(string msg)
    {
        Debug.LogException(new System.Exception(msg));
    }
}
