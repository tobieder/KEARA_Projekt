using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class BarcodeTester : MonoBehaviour
{
    public Webcam webcam;
    private WebCamTexture wCamTexture;
    private Rect screenRect;
    Image scanArea;

    int delay = 0;

    void Awake()
    {
        scanArea = transform.GetComponent<Image>();
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        wCamTexture = webcam.GetWebCamTexture();
        if (wCamTexture != null)
        {
            wCamTexture.Play();
        }
    }

    void Update()
    {
        delay++;
        if (delay == 10)
        {
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                var result = barcodeReader.Decode(wCamTexture.GetPixels32(),
                  wCamTexture.width, wCamTexture.height);
                if (result != null)
                {
                    Debug.Log("Qr-Code read: " + result);
                }
                else
                {
                    Debug.Log("No QR-Code Found");
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            delay = 0;
        }
    }
}
