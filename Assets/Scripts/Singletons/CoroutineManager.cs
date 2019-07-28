using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    static CoroutineManager mInstance;
    public static CoroutineManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                CustomDebug.LogException("Trying to get instance of CoroutineManager while it is not ready");
            }
            return mInstance;
        }
    }

    void Awake()
    {
        if (mInstance == null)
        {
            mInstance = this;
        }
        else
        {
            CustomDebug.Log("Multiple instance found for CoroutineManager destroying automatically");
            Destroy(this);
        }
    }
}
