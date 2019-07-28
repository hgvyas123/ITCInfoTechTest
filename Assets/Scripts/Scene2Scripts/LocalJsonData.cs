using System;
using Newtonsoft.Json;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LocalJsonData : MonoBehaviour
{
    [SerializeField] InputField mIFFirstName, mIFLastName, mIFEmail, mIFMobileNumber;

    const string PLAYERDATAFILENAME = "PlayerData.json";

    public void OnBtnSaveClicked()
    {
        StringBuilder error = new StringBuilder("There were following errors\n\n");
        bool isEverythingValid = true;
        if (mIFFirstName.text.Length < 3)
        {
            isEverythingValid = false;
            error.AppendLine("Enter first name with minimum 3 characters.");
        }

        if (mIFLastName.text.Length < 3)
        {
            isEverythingValid = false;
            error.AppendLine("Enter last name with minimum 3 characters");
        }

        if (!mIFEmail.text.IsValidEmailAddress())
        {
            isEverythingValid = false;
            error.AppendLine("Enter valid email.");
        }
        
        if (!mIFMobileNumber.text.IsValidMobileNumber())
        {
            isEverythingValid = false;
            error.AppendLine("Enter mobile number with 10 digit.");
        }

        if (!isEverythingValid)
        {
            error.ToString().ShowAsAlert();
        }
        else
        {
            PlayerData playerData = new PlayerData(mIFFirstName.text, mIFLastName.text, mIFEmail.text, mIFMobileNumber.text);
            string json = JsonConvert.SerializeObject(playerData);
            FileUtility.SaveToPersistentFile(PLAYERDATAFILENAME, json);
        }
    }

    public void OnBtnResetClicked()
    {
        mIFFirstName.text = mIFLastName.text = mIFEmail.text = mIFMobileNumber.text = string.Empty;
    }

    public void OnBtnLoadLastSavedClicked()
    {
        try
        {
            string json = FileUtility.GetDataFromPersistentFile(PLAYERDATAFILENAME);
            if (!string.IsNullOrEmpty(json))
            {
                PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(json);
                mIFFirstName.text = playerData.pFirstName;
                mIFLastName.text = playerData.pLastName;
                mIFEmail.text = playerData.pEmail;
                mIFMobileNumber.text = playerData.pMobileNumber;
            }
            else
            {
                "No data saved currently please first save data".ShowAsAlert();
            }
        }
        catch (Exception ex)
        {
            CustomDebug.LogException("Custom exception while trying to load saved data : "+ex.Message);
            ex.Message.ShowAsAlert();
        }
    }
}
