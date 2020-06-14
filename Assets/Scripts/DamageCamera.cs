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

        //AppData/LocalLow/HS Kempten/KEARA
        string outFilename = Path.Combine(Application.persistentDataPath, "damage_" + DateTime.Now.ToString().Replace(":", "_") + ".jpg");
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
