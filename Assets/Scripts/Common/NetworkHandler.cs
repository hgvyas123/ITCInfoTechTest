using System;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkHandler
{
    /// <summary>
    /// Get data from webservice in worker thread
    /// </summary>
    public static void GetData(string url,Action<object> OnGetData)
    {
        Thread thread = new Thread(() => StartDownloadingData(url, OnGetData));
        thread.Start();
    }
    /// <summary>
    /// Get the image from given url
    /// </summary>
    public static void GetImage(string url,Action<Texture2D> OnGetImage)
    {
        CoroutineManager.Instance.StartCoroutine(GetImageFromURL(url, OnGetImage));
    }

    static IEnumerator GetImageFromURL(string url, Action<Texture2D> OnGetImage)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            OnGetImage(null);
        }
        else
        {
            OnGetImage(((DownloadHandlerTexture)request.downloadHandler).texture);
        }
    }

    static void StartDownloadingData(string url, Action<object> OnGetData)
    {
        ServicePointManager.ServerCertificateValidationCallback += (send, certificate, chain, sslPolicyErrors) => { return true; };
        using (WebClient client = new WebClient())
        {
            try
            {
                string response = client.DownloadString(url);
                response = Regex.Replace(response, @"\\u([\dA-Fa-f]{4})", v => ((char)Convert.ToInt32(v.Groups[1].Value, 16)).ToString());
                //As we can not access any Unity related API in worker thread dispatching the result in main thread via helper class
                UnityMainThread.ExecuteOnMainThread(OnGetData, response);
            }
            catch (Exception ex)
            {
                UnityMainThread.ExecuteOnMainThread(OnGetData, ex);
            }
        }
    } 
}
