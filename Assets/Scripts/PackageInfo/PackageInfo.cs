using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DataProvider;


public class PackageInfo : MonoBehaviour
{
    public TextMeshProUGUI packageTitle;
    public TextMeshProUGUI packageInfo;
    public string packageCode = "400000000000400006";

    private string[] PackageStatusName = new string[] { "No status", "Scanned successfully", "Package is missing", "Package is damaged", "Barcode is missing" };
    
    void Start()
    {
        if (!String.IsNullOrEmpty(packageCode))
        {
            ShowPackageInfo(packageCode);
        }
    }

    public void ShowPackageInfo(string packageCode)
    {
        ////////////// for testing //////////////
        DataManager.Instance.setCurrentTour(172839);
        /////////////////////////////////////////

        PackageData package = DataManager.Instance.getPackage(packageCode);

        string infoString = "";

        if (package != null)
        {
            string lane = package.destinationLane.designation;
            packageTitle.text = "[ " + lane + " ]";


            int packageIndex = Array.FindIndex(DataManager.Instance.currentTour.ssccs, it => it.code == packageCode) + 1;
            int tourPackagesCount = DataManager.Instance.currentTour.ssccs.Length;
            infoString += "Package: " + packageIndex.ToString() + "/" + tourPackagesCount.ToString() + "\n";

            infoString += "Item: " + packageCode + "\n";

            infoString += "Weight: " + package.weight.ToString() + " KG\n";

            infoString += "Status: " + PackageStatusName[package.SSCCStatus] + "\n";

            if (!String.IsNullOrEmpty(package.comment))
            {
                infoString += "Comment: " + package.comment + "\n";
            }
        }
        else
        {
            infoString = "Package Not Found";
        }

        packageInfo.text = infoString;
    }
}
