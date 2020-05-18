using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
<<<<<<< HEAD
using DataProvider;
=======
<<<<<<< HEAD:Assets/QR-CodeScanning/BarcodeScanning.cs
using DataProvider;
=======
using TMPro;
>>>>>>> 97678495fc0630cc70dd95100b1123e428a9ef46:Assets/Scripts/QR-CodeScanning/BarcodeScanning.cs
>>>>>>> 03d8b7450f80f70de0e3e2d66f114563d08757cb

public class BarcodeScanning : MonoBehaviour
{
    public Webcam webcam;
    public string sDatatype;

    private WebCamTexture wCamTexture;
    private Rect screenRect;
    [SerializeField]
    public DataProvider.DataProvider data;

<<<<<<< HEAD
    [SerializeField]
    public DataProvider.DataProvider data;
=======
    public Webcam webcam;
    public string sDatatype;
>>>>>>> 03d8b7450f80f70de0e3e2d66f114563d08757cb

    int delay = 0;

    Image scanArea;

    Color white = new Color(255.0f, 255.0f, 255.0f);
    Color reading = new Color(255.0f, 165.0f, 0.0f);
    Color accepted = new Color(0.0f, 255.0f, 0.0f);
    Color rejected = new Color(255.0f, 0.0f, 0.0f);

    public GameObject nextUI;

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
<<<<<<< HEAD
    private void Update()
    {
        delay++;
        if (delay == 10)
=======

    private void Update()
    {
<<<<<<< HEAD:Assets/QR-CodeScanning/BarcodeScanning.cs
            delay++;
            if (delay == 10)
=======
        //GUI.DrawTexture(screenRect, wCamTexture, ScaleMode.ScaleToFit); // <- Optional: draw webcam on the Screen
        int count = 0;
        if (count == 0)
>>>>>>> 03d8b7450f80f70de0e3e2d66f114563d08757cb
        {
            try
>>>>>>> 97678495fc0630cc70dd95100b1123e428a9ef46:Assets/Scripts/QR-CodeScanning/BarcodeScanning.cs
            {
<<<<<<< HEAD
                IBarcodeReader barcodeReader = new BarcodeReader();
                var result = barcodeReader.Decode(wCamTexture.GetPixels32(),
                  wCamTexture.width, wCamTexture.height);

                if (result != null)
=======
                try
>>>>>>> 03d8b7450f80f70de0e3e2d66f114563d08757cb
                {
<<<<<<< HEAD:Assets/QR-CodeScanning/BarcodeScanning.cs
                    IBarcodeReader barcodeReader = new BarcodeReader();
                    // decode the current frame
                    var result = barcodeReader.Decode(wCamTexture.GetPixels32(),
                      wCamTexture.width, wCamTexture.height);

                    if (result != null)
                    {
                        Debug.Log("DECODED TEXT FROM QR: " + result.Text);
                        switch (sDatatype)
                        {
                            case "login":
                                UserData user = data.FindUserById(result.Text);
                                if (user != null)
                                {
                                    Debug.Log("User found");
                                    scanArea.color = accepted;
                                    SwitchUI();
                                }
                                else
                                {
                                    scanArea.color = rejected;
                                    Debug.Log("User Not Found");
                                }
                                break;

                            case "tour":
                                TourData tour = data.FindTourById(result.Text);
                                if (tour != null)
                                {
                                    Debug.Log("Tour found");
                                    scanArea.color = accepted;
                                    SwitchUI();
                                }
                                else
                                {
                                    scanArea.color = rejected;
                                    Debug.Log("Tour Not Found");
                                }
                                break;

                            case "package":
                                PackageData package = data.FindPackageById(result.Text); ;
                                if (package != null)
                                {
                                    Debug.Log("Package found");
                                    scanArea.color = accepted;
                                    SwitchUI();
                                }
                                else
                                {
                                    scanArea.color = rejected;
                                    Debug.Log("Package Not Found");
                                }
                                break;
                            default:
                                Debug.Log("datatype not given");
                                scanArea.color = rejected;
                                break;
                        }
                    }
=======
                    Debug.Log("DECODED TEXT FROM QR: " + result.Text);
<<<<<<< HEAD
                    switch (sDatatype)
                    {
                        case "login":
                            UserData user = data.FindUserById(result.Text);
                            if (user != null)
                            {
                                Debug.Log("User found");
                                scanArea.color = accepted;
                                SwitchUI();
                            }
                            else
                            {
                                scanArea.color = rejected;
                                Debug.Log("User Not Found");
                            }
                            break;

                        case "tour":
                            TourData tour = data.FindTourById(result.Text);
                            if (tour != null)
                            {
                                Debug.Log("Tour found");
                                scanArea.color = accepted;
                                SwitchUI();
                            }
                            else
                            {
                                scanArea.color = rejected;
                                Debug.Log("Tour Not Found");
                            }
                            break;

                        case "package":
                            PackageData package = data.FindPackageById(result.Text); ;
                            if (package != null)
                            {
                                Debug.Log("Package found");
                                scanArea.color = accepted;
                                SwitchUI();
                            }
                            else
                            {
                                scanArea.color = rejected;
                                Debug.Log("Package Not Found");
                            }
                            break;
                        default:
                            Debug.Log("datatype not given");
                            scanArea.color = rejected;
                            break;
                    }
                }
                    Debug.Log("DECODED TEXT FROM QR: " + result.Text);
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
