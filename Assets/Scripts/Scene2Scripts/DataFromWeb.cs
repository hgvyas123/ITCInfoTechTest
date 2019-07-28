using System;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DataFromWeb : MonoBehaviour
{
    [SerializeField] Text mLblTitle, mLblId, mLblName, mLblEmail;
    [SerializeField] RawImage mImgFromWeb;
    [SerializeField] int mImgFromWebMaxAllowedDimention = 800;

    const string WEBSERVICEURL = "https://graph.facebook.com/me?fields=name,email&access_token=EAAFAZCOvPpNsBAJyNCbPZBFFA7ZB7VEdYqMmNBhwZAA8sCbtJWveMFlvpWyjnftZCuzZCu9Jk6t9wI56ZCjtBZAovapFCcGL1bhqF9ZCy5TYzwiQd9GiGpwaulDBZBvZBOvcV4EaCDdzeUyZA59HSMFY3oyPGqpZB9PeiAMVPyfGjYDyU4QZDZD";
    const string IMAGEURL1 = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/67/Ajay_Devgn_at_the_launch_of_MTV_Super_Fight_League.jpg/220px-Ajay_Devgn_at_the_launch_of_MTV_Super_Fight_League.jpg";
    const string IMAGEURL2 = "https://www.hindustantimes.com/rf/image_size_960x540/HT/p2/2017/09/11/Pictures/actor-ajay-devgan-photo-credits-shamim-ansari_9ff9578c-96df-11e7-bef3-183dfba5e438.jpg";
    // Start is called before the first frame update
    void Start()
    {
        mLblTitle.text = "Loading data from Web Api";
        //Getting data from URL via Worker thread
        NetworkHandler.GetData(WEBSERVICEURL, OnGetData);
        //Getting image from URL via UnityWebRequest
        if (Random.Range(0, 100) < 50)
        {
            NetworkHandler.GetImage(IMAGEURL1, OnGetImage);
        }
        else
        {
            NetworkHandler.GetImage(IMAGEURL2, OnGetImage);
        }
    }

    void OnGetImage(Texture2D inTexture)
    {
        if (inTexture != null)
        {
            RectTransform rect = mImgFromWeb.GetComponent<RectTransform>();
            rect.ResizeAsPerTextureSize(mImgFromWebMaxAllowedDimention, inTexture);
            mImgFromWeb.texture = inTexture;
        }
    }

    void OnGetData(object inData)
    {
        if (inData is Exception)
        {
            Exception ex = (Exception)inData;
            CustomDebug.LogException("Custom Exception while getting data from webservice : " + ex.Message);
            "Some thing went wrong please check your internet connection and try later".ShowAsAlert();
            mLblTitle.text = "Failed to get data from Web";
        }
        else
        {
            try
            {
                string json = (string)inData;
                PlayerDataFromAPI playerData = JsonConvert.DeserializeObject<PlayerDataFromAPI>(json);
                mLblTitle.text = "Data From WebService";
                mLblId.text = playerData.pId;
                mLblName.text = playerData.pName;
                mLblEmail.text = playerData.pEmail;
            }
            catch (Exception ex)
            {
                CustomDebug.LogException("Custom exception while parsing data from webapi : "+ex.Message);
                mLblTitle.text = "Failed to show data";
            }
        }
    }
}
