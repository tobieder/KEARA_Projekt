using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webcam : MonoBehaviour
{
    WebCamTexture wCamTexture;
    void Start()
    {
        wCamTexture = new WebCamTexture();
        wCamTexture.requestedHeight = Screen.height;
        wCamTexture.requestedWidth = Screen.width;
    }

    public WebCamTexture GetWebCamTexture()
    {
        return wCamTexture;
    }
}
