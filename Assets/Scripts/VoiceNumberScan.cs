using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VoiceNumberScan : MonoBehaviour
{
    public TextMeshProUGUI numberInput;
    public GameObject nextUI;

    string number;

    public void VoiceCommandNumber()
    {
        StartCoroutine("EnterRandomNumber");
    }

    IEnumerator EnterRandomNumber()
    {
        number = "";
        foreach (Button button in transform.parent.GetComponentsInChildren<Button>())
        {
            button.interactable = false;
        }
        for (int i = 0; i < 14; i++)
        {
            int currNumber = (int)Random.Range(0.0f, 9.0f);
            number += currNumber.ToString();
            numberInput.text = number;
            yield return new WaitForSeconds(0.5f);
        }
        foreach (Button button in transform.parent.GetComponentsInChildren<Button>())
        {
            button.interactable = true;
        }
        if (nextUI != null)
        {
            nextUI.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
