using System.Collections.Generic;
using UnityEngine;
using System;

public class UnityMainThread : MonoBehaviour
{
    static Stack<Action<object>> mStackParameterized = new Stack<Action<object>>();
    static Stack<object> mStackParameterizedData = new Stack<object>();

    /// <summary>
    /// Execute result on Unity main thread as we can not use any unity related API in worker thread
    /// </summary>
    public static void ExecuteOnMainThread(Action<object> action,object data)
    {
        lock (mStackParameterized)
        {
            mStackParameterized.Push(action);
            lock (mStackParameterizedData)
            {
                mStackParameterizedData.Push(data);
            }
        }
    }

    /// <summary>
    /// Will execute in main thread if any action are registored
    /// </summary>
    void Update ()
    {
        lock (mStackParameterized)
        {
            lock (mStackParameterizedData)
            {
                while (mStackParameterized.Count > 0)
                {
                    Action<object> action = mStackParameterized.Pop();
                    object data = mStackParameterizedData.Pop();
                    action(data);
                }
            }
        }
    }
    
}
