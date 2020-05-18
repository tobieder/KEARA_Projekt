using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataProvider;
using TMPro;

public class ScanSimulator : MonoBehaviour
{
    Image scanArea;

    Color white = new Color(255.0f, 255.0f, 255.0f);
    Color reading = new Color(255.0f, 165.0f, 0.0f);
    Color accepted = new Color(0.0f, 255.0f, 0.0f);
    Color rejected = new Color(255.0f, 0.0f, 0.0f);

    public GameObject nextUI;
    public GameObject LoginFailerPanel;
    public GameObject EmployeeNamePanel;
    public TextMeshProUGUI EmployeeNameText;

    void Start()
    {
        scanArea = transform.GetComponent<Image>();
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
        scanArea.color = reading;

        yield return new WaitForSeconds(2.0f);

        if (Random.Range(0.0f, 1.0f) > 0.3f)
        {
            scanArea.color = accepted;
            if (nextUI != null)
            {
                yield return new WaitForSeconds(0.2f);
                scanArea.color = white;
                nextUI.SetActive(true);
                transform.parent.gameObject.SetActive(false);
            }
        }
        else
        {
            scanArea.color = rejected;
        }

        yield return new WaitForSeconds(1.0f);

        scanArea.color = white;
    }

    public void login(string id)
    {
        // gets the data of the employee if one was found and if not employee will be null
        UserData employee = DataManager.Instance.Login(id);

        if (employee != null)
        {
            // if employee with id was found next scene will be loaded and employee name panel will be filled
            transform.gameObject.SetActive(false);
            nextUI.SetActive(true);
            LoginFailerPanel.SetActive(false);
            EmployeeNamePanel.SetActive(true);
            EmployeeNameText.text = employee.name;
        }
        else
        {
            // if employee with id NOT found an error message will be displayed to notify the user to try to scan again
            LoginFailerPanel.SetActive(true);
        }
    }
}
