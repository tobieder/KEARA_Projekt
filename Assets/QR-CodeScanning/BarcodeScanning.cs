using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class BarcodeScanning : MonoBehaviour
{
    private WebCamTexture wCamTexture;
    private Rect screenRect;

    void Start()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        wCamTexture = new WebCamTexture();
        wCamTexture.requestedHeight = Screen.height;
        wCamTexture.requestedWidth = Screen.width;
        if (wCamTexture != null)
        {
            wCamTexture.Play();
        }
    }
    private static Color32[] Encode(string textForEncoding,
    int width, int height)
    {
        var bWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return bWriter.Write(textForEncoding);
    }
    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    void OnGUI()
    {
        GUI.DrawTexture(screenRect, wCamTexture, ScaleMode.ScaleToFit); // <- Optional: draw webcam on the Screen
        int count = 0;
        if (count == 0)
        {
            try
            {
                IBarcodeReader barcodeReader = new BarcodeReader();
                // decode the current frame
                var result = barcodeReader.Decode(wCamTexture.GetPixels32(),
                  wCamTexture.width, wCamTexture.height);
                if (result != null)
                {
                    Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            count = 0;
        }
        count++;
    }
}
