using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataProvider;
using TMPro;

public class PartialPackageListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private TextMeshProUGUI titel;

    [SerializeField]
    private int packageMode;

    List<PackageData> tourPackages;

    private DataManager manager;

    private List<GameObject> packageButtons;

    public GameObject currentUI;
    public GameObject reportUI;

    private void Start()
    {
        manager = DataManager.Instance;
        packageButtons = new List<GameObject>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        switch (packageMode)
        {
            case 0:
                titel.text = "Missing of Tour: " + manager.currentTour.id;
                break;
            case 1:
                titel.text = "Correct of Tour: " + manager.currentTour.id;
                break;
            case 2:
                titel.text = "Errors of Tour: " + manager.currentTour.id;
                break;
            case 3:
                titel.text = "Added of Tour: " + manager.currentTour.id;
                break;
        }
        foreach (var t in manager.currentTour.ssccs)
        {
            if(t.SSCCStatus == packageMode)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);

                PackageListButton packageListButton = button.GetComponent<PackageListButton>();
                packageListButton.SetText(t.code);

                packageListButton.currentUI = currentUI;
                packageListButton.nextUI = reportUI;

                button.transform.SetParent(buttonTemplate.transform.parent, false);

                packageButtons.Add(button);
            }
        }
    }

    void OnDisable()
    {
        foreach (GameObject go in packageButtons)
        {
            Destroy(go);
        }

        packageButtons.Clear();

        Debug.Log(packageButtons.Count);
    }

    public void SetPackageMode(int mode)
    {
        packageMode = mode;
    }
}
