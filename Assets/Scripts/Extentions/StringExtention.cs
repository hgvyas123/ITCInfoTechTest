using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public static class StringExtention
{
    /// <summary>
    /// show message as a alert
    /// will replace any current message if called while one message is already there
    /// </summary>
    /// <param name="str"></param>
    public static void ShowAsAlert(this string str)
    {
        UIAlert.Instance.ShowAlert(str);
    }
    /// <summary>
    /// validates the email
    /// </summary>
    /// <param name="emailaddress"></param>
    /// <returns></returns>
    public static bool IsValidEmailAddress(this string emailaddress)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return regex.Match(emailaddress).Success;
    }
    /// <summary>
    /// Validates the phone number
    /// </summary>
    /// <param name="mobileNumber"></param>
    /// <returns></returns>
    public static bool IsValidMobileNumber(this string mobileNumber)
    {
        if(mobileNumber.Length == 10)
        {
            foreach (char c in mobileNumber)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}