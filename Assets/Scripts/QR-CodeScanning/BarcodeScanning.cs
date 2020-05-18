using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
<<<<<<< HEAD:Assets/QR-CodeScanning/BarcodeScanning.cs
using DataProvider;
=======
using TMPro;
>>>>>>> 97678495fc0630cc70dd95100b1123e428a9ef46:Assets/Scripts/QR-CodeScanning/BarcodeScanning.cs

public class BarcodeScanning : MonoBehaviour
{
    public TextMeshProUGUI QROutup;

    private WebCamTexture wCamTexture;
    private Rect screenRect;
    [SerializeField]
    public DataProvider.DataProvider data;

    public Webcam webcam;
    public string sDatatype;

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
        wCamTexture = webcam.getWebcamTexture();
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
<<<<<<< HEAD:Assets/QR-CodeScanning/BarcodeScanning.cs
            delay++;
            if (delay == 10)
=======
        //GUI.DrawTexture(screenRect, wCamTexture, ScaleMode.ScaleToFit); // <- Optional: draw webcam on the Screen
        int count = 0;
        if (count == 0)
        {
            try
>>>>>>> 97678495fc0630cc70dd95100b1123e428a9ef46:Assets/Scripts/QR-CodeScanning/BarcodeScanning.cs
            {
                try
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
                    QROutup.text = result.Text;
>>>>>>> 97678495fc0630cc70dd95100b1123e428a9ef46:Assets/Scripts/QR-CodeScanning/BarcodeScanning.cs
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
