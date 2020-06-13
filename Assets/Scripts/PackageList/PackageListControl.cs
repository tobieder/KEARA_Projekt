using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataProvider;
using TMPro;

public class PackageListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private DataManager manager;

    [SerializeField]
    private TextMeshProUGUI titel;

    List<PackageData> tourPackages;



    private void Start()
    {
        manager.setCurrentTour("5678");
        titel.text = "Tour: " + manager.currentTour.id;
        foreach (var t in manager.currentTour.packagesList)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<PackageListButton>().SetText(t);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
    void GenButtons()
    {

    }
}
