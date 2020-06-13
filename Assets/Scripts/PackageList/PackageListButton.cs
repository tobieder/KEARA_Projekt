using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PackageListButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myText;

    public void SetText(string textstring)
    {
        myText.text = textstring;
    }

    public void OnClick()
    {

    }
}
