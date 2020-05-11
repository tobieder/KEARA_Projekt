using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentDateTime : MonoBehaviour
{
    public TextMeshProUGUI dateTimeOutput;

    private void Update()
    {
        string time = System.DateTime.Now.Hour.ToString("D2") + ":" + System.DateTime.Now.Minute.ToString("D2") + "." + System.DateTime.Now.Second.ToString("D2");
        string date = System.DateTime.Now.Day.ToString("D2") + "." + System.DateTime.Now.Month.ToString("D2") + "." + System.DateTime.Now.Year.ToString();

        dateTimeOutput.text = "[" + date + " | " + time + "]";
    }
}
