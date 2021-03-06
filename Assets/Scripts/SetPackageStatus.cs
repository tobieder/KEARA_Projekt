﻿using DataProvider;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPackageStatus : MonoBehaviour
{
    [SerializeField]
    private PackageListControl packageListcontrol;
    public PackageReportCode packageStatus;

    [SerializeField]
    private PackageProgress packageProgressExtended;
    [SerializeField]
    private PackageProgress packageProgressContracted;

    private DataManager manager;

    private void Start()
    {
        manager = DataManager.Instance;
    }

    public void setCurrentPackageStatus()
    {
        manager.currentPackage.SSCCStatus = (int)packageStatus;

        packageListcontrol.UpdateList();
        packageProgressExtended.UpdateProgressBar();
        packageProgressContracted.UpdateProgressBar();
    }
}
