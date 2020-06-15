using System;
using System.IO;
using UnityEngine;

public class DamageCamera : MonoBehaviour
{
    public GameObject nextUI;

    private WebCamTexture webCamTexture;

    void Start()
    {
        webCamTexture = GameObject.FindGameObjectWithTag("Manager").GetComponent<Webcam>().GetWebCamTexture();
        webCamTexture.Play();
    }

    public void CreateSnapshot()
    {
        Texture2D snapshot = new Texture2D(webCamTexture.width, webCamTexture.height);
        snapshot.SetPixels32(webCamTexture.GetPixels32());

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "KEARA");
        Directory.CreateDirectory(path);
        string outFilename = Path.Combine(path, "damage_" + DateTime.Now.ToString().Replace(":", "_") + ".jpg");
        File.WriteAllBytes(outFilename, snapshot.EncodeToJPG());
        Debug.Log("Saved image to " + outFilename);

        webCamTexture.Stop();

        transform.parent.gameObject.SetActive(false);
        if (nextUI != null)
        {
            nextUI.SetActive(true);
        }
    }
}
