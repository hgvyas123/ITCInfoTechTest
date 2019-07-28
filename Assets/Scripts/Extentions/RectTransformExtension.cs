using UnityEngine;

public static class RectTransformExtension
{
    /// <summary>
    /// Resize the Rect transform as per image width and height so image will not skew
    /// </summary>
    public static void ResizeAsPerTextureSize(this RectTransform rect,float maxSizeAllowed,Texture2D texture)
    {
        float imageWidth, imageHeight = 0.0f;
        if (texture.width > texture.height)
        {
            imageWidth = maxSizeAllowed;
            imageHeight = texture.height * imageWidth / texture.width;
        }
        else if (texture.width < texture.height)
        {
            imageHeight = maxSizeAllowed;
            imageWidth = texture.width * imageHeight / texture.height;
        }
        else
        {
            imageWidth = imageHeight = maxSizeAllowed;
        }
        rect.sizeDelta = new Vector2(imageWidth, imageHeight);
    }
}
