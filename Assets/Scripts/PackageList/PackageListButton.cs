using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DataProvider;

public class PackageListButton : MonoBehaviour
{
    string id;

    [SerializeField]
    private TextMeshProUGUI myText;

    public GameObject currentUI;
    public GameObject nextUI;

    Color[] buttonColors =
    {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 1.0f, 0.0f),
        new Color(1.0f, 0.0f, 0.0f),
        new Color(1.0f, 0.0f, 0.0f),
        new Color(1.0f, 0.0f, 0.0f)
    };

    public void SetText(string textstring)
    {
        myText.text = textstring;
        id = textstring;
    }

    public void OnClick()
    {
        DataManager.Instance.SetCurrentPackage(id);
        SwitchUI();
    }

    public void SwitchUI()
    {
        nextUI.SetActive(true);
        currentUI.SetActive(false);
    }

    private void OnEnable()
    {
        if (DataManager.Instance.getPackage(id) != null)
        {
            int status = DataManager.Instance.getPackage(id).SSCCStatus;

            gameObject.GetComponent<Image>().color = buttonColors[status];
        }
    }
}
