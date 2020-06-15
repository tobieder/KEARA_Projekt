using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageReporter : MonoBehaviour
{
    public PackageReportCode reportCode;
    public GameObject currentUI;
    public GameObject nextUI;

    public void ReportCurrentPackage()
    {
        // the next 2 lines are only for testing. currentPackage and currentTour should be set before 
        // the user comes to this scene
        //DataManager.Instance.setCurrentTour(567890123);
        //DataManager.Instance.setCurrentTour(139149);
        //DataManager.Instance.SetCurrentPackage("400000000000400090");
        //////////////////////////////////
        
        bool success = DataManager.Instance.ReportCurrentPackage(reportCode);
        if (!success)
        {
            Debug.Log("Failed to report package!");
        }
        switchUI();
    }

    private void switchUI()
    {
        nextUI.SetActive(true);
        currentUI.SetActive(false);
    }

}
