using UnityEngine;
using UnityEngine.UI;

public class UIAlert : MonoBehaviour
{
    [SerializeField] Text mTxtMsg;
    [SerializeField] Canvas mCanvas;
    [SerializeField] GraphicRaycaster mCanvasGraphicRayCaster;

    //Singleton for easy access though out project
    static UIAlert mInstance;
    public static UIAlert Instance
    {
        get
        {
            if(mInstance == null)
            {
                CustomDebug.LogException("Trying to get instance of UIAlert while it is not ready");
            }
            return mInstance;
        }
    }

    void Awake()
    {
        if(mInstance == null)
        {
            mInstance = this;
            HideMe();
        }
        else
        {
            CustomDebug.Log("Multiple instance found for UIAlert destroying automatically");
            Destroy(this);
        }
    }

    void HideMe()
    {
        //this will not make canvas dirty while still hiding it
        mCanvas.enabled = false;
        mCanvasGraphicRayCaster.enabled = false;
    }

    void ShowMe()
    {
        mCanvas.enabled = true;
        mCanvasGraphicRayCaster.enabled = true;
    }

    /// <summary>
    /// Will show alert in a popup with ok button to dismiss
    /// </summary>
    public void ShowAlert(string alert)
    {
        ShowMe();
        mTxtMsg.text = alert;
    }
    /// <summary>
    /// will hide Alert popup
    /// Should be called on ok button click via Editor
    /// </summary>
    public void OnBtnOkClicked()
    {
        HideMe();
    }
}
