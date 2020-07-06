using UnityEngine;

public class EmployeeInformationPanelController : MonoBehaviour
{
    public GameObject EmployeePanel;
    public bool useOnEnable;
    public bool useOnDisable;

    private void OnEnable()
    {
        if (useOnEnable)
        {
            Debug.Log("EIPC enabled");
            EmployeePanel.SetActive(true);
        }
    }

    private void OnDisable()
    {

        if (useOnDisable)
        {
            Debug.Log("EIPC disabled");
            EmployeePanel.SetActive(false);
        }
    }
}
