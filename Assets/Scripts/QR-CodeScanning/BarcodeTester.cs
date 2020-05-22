using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using TMPro;

public class BarcodeTester : MonoBehaviour
{
    private WebCamTexture wCamTexture;
    private Rect screenRect;
    Image scanArea;

    float delay = 0.0f;

    public TextMeshProUGUI output;

    void Awake()
    {
        scanArea = transform.GetComponent<Image>();
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        wCamTexture = new WebCamTexture();
        wCamTexture.requestedHeight = Screen.height;
        wCamTexture.requestedWidth = Screen.width;
        if (wCamTexture != null)
        {
            wCamTexture.Play();
        }
        else
        {
            Debug.LogError("No webcam found");
        }
    }

    void Update()
    {
        delay += Time.deltaTime;
        if (delay >= 1)
        {
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                var result = barcodeReader.Decode(wCamTexture.GetPixels32(), wCamTexture.width, wCamTexture.height);
                if (result != null)
                {
                    Debug.Log("Qr-Code read: " + result);
                    output.text = result.ToString();
                }
                else
                {
                    Debug.Log("No QR-Code Found");
                    output.text = "---";
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            delay = 0.0f;
        }
    }
}
