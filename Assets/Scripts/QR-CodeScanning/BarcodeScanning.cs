using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using DataProvider;

public class BarcodeScanning : MonoBehaviour
{
    private Webcam webcam;
    public CheckIdType sDatatype;

    private WebCamTexture wCamTexture;
    private Rect screenRect;

    private DataManager manager;

    int delay = 0;

    Image scanArea;

    Color white = new Color(255.0f, 255.0f, 255.0f);
    Color reading = new Color(255.0f, 165.0f, 0.0f);
    Color accepted = new Color(0.0f, 255.0f, 0.0f);
    Color rejected = new Color(255.0f, 0.0f, 0.0f);

    public GameObject nextUI;
    public GameObject ErrorUI;

    private GameObject gameManager;

    void Awake()
    {
        scanArea = transform.GetComponent<Image>();
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        gameManager = GameObject.FindGameObjectWithTag("Manager");
        manager = gameManager.GetComponent<DataManager>();
        wCamTexture = gameManager.GetComponent<Webcam>().GetWebCamTexture();
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

    private void Update()
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
                    Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                    manager.CheckID(result.Text, sDatatype, transform.parent.gameObject, nextUI, ErrorUI);
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            delay = 0;
        }
    }
    public void SwitchUI()
    {
        scanArea.color = white;
        nextUI.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}