using TMPro;
using UnityEngine;

public class EmployeeButton : MonoBehaviour
{
    public GameObject logoutScreen;
    public GameObject[] gameobjectsToDisable;

    public TextMeshProUGUI employeeInformation;

    private void Start()
    {
        if (DataManager.Instance.currentEmployee != null)
        {
            employeeInformation.text = DataManager.Instance.currentEmployee.name + "\n" + DataManager.Instance.currentEmployee.id;
        }
    }

    public void ButtonPressed()
    {
        foreach (GameObject go in gameobjectsToDisable)
        {
            go.SetActive(false);
        }

        logoutScreen.SetActive(true);
    }
}
