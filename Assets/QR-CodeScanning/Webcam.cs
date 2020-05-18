using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webcam : MonoBehaviour
{
    private WebCamTexture wCamTexture;
    void Start()
    {
        wCamTexture = new WebCamTexture();
        wCamTexture.requestedHeight = Screen.height;
        wCamTexture.requestedWidth = Screen.width;
    }

    // Update is called once per frame
    public WebCamTexture getWebcamTexture()
    {
        return wCamTexture;
    }
}
