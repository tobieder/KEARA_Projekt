using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanSimulator : MonoBehaviour
{
    Image scanArea;

    Color white = new Color(255.0f, 255.0f, 255.0f);
    Color reading = new Color(255.0f, 165.0f, 0.0f);
    Color accepted = new Color(0.0f, 255.0f, 0.0f);
    Color rejected = new Color(255.0f, 0.0f, 0.0f);

    public GameObject nextUI;
    private BackendManager backendManger = BackendManager.Instance;

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

        Employee employee = backendManger.login(id);

        if (employee != null)
        {
            transform.gameObject.SetActive(false);
            nextUI.SetActive(true);
        }
        else
        {
            Debug.Log("employee null");
        }

        if(backendManger.currentEmployee != null)
        {
            Debug.Log(backendManger.currentEmployee.name);
        }
        else
        {
            Debug.Log("employee null2");
        }
    }
}
