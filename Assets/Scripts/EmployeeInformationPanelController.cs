using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeInformationPanelController : MonoBehaviour
{
    public GameObject EmployeePanel;
    public bool useOnEnable;
    public bool useOnDisable;

    private void OnEnable()
    {
        if(useOnEnable)
        {
            EmployeePanel.SetActive(true);
        }
    }

    private void OnDisable()
    {
        Debug.Log("EIPC disabled");
        if(useOnDisable)
        {
            EmployeePanel.SetActive(false);
        }
    }
}
