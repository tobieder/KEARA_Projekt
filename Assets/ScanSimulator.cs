using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScanSimulator : MonoBehaviour
{
    public DataProvider.DataProvider dProvider;

    string[] saIdCollection =
    {
        "1234",
        "123456789abcd"
    };

    Image iScanArea;

    Color cWhite = new Color(255.0f, 255.0f, 255.0f);
    Color cReading = new Color(255.0f, 165.0f, 0.0f);
    Color cAccepted = new Color(0.0f, 255.0f, 0.0f);
    Color cRejected = new Color(255.0f, 0.0f, 0.0f);

    void Start()
    {
        iScanArea = transform.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            StartCoroutine(ReadID());
        }
    }

    IEnumerator ReadID()
    {
        iScanArea.color = cReading;

        yield return new WaitForSeconds(2.0f);

        if (dProvider.FindUserById(saIdCollection[Random.Range(0, saIdCollection.Length)]) != null)
        {
            iScanArea.color = cAccepted;
        }
        else
        {
            iScanArea.color = cRejected;
        }

        yield return new WaitForSeconds(1.0f);

        iScanArea.color = cWhite;
    }
}
