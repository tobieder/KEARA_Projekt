using DataProvider;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum CheckIdType { login, tour, package };

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public DataProvider.DataProvider data;
    public UserData currentEmployee = null;

    public TourData currentTour = null;
    public List<(string id, bool scanned)> currentTourPackages = new List<(string id, bool scanned)>();

    public PackageData currentPackage = null;

    private float shiftStartTime = 0.0f;
    private bool clockedIn = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool Login(string employeeID)
    {
        currentEmployee = data.FindUserById(employeeID);

        if (currentEmployee != null)
        {
            Debug.Log(currentEmployee.name + " Logged in successfully");
            return true;
        }
        else
        {
            Debug.Log("UserId not found: " + employeeID);
            return false;
        }
    }

    public void Logout()
    {
        string employeeID = currentEmployee.id;
        currentEmployee = null;
        Debug.Log("Employee: " + employeeID + " successfully logged out");

        ClockOut();
    }

    public void ClockIn()
    {
        shiftStartTime = Time.time;
        clockedIn = true;
    }

    public void ClockOut()
    {
        clockedIn = false;
        float currentTime = Time.time;

        float shift = currentTime - shiftStartTime;
        int shiftInt = (int)shift;
        Debug.Log("Total Shift Time in Seconds: " + shiftInt.ToString());
    }

    public bool setCurrentTour(int tourId)
    {
        currentTour = data.FindTourById(tourId);

        if (currentTour != null)
        {
            Debug.Log(currentTour.id + " Tour started.");
            for (int i = 0; i < currentTour.ssccs.Length; i++)
            {
                PackageData package = currentTour.ssccs[i];
                currentTourPackages.Add((package.code, false));
            }
            return true;
        }
        else
        {
            Debug.Log("TourID not found: " + tourId.ToString());
            return false;
        }
    }

    public void EndCurrentTour()
    {
        EndCurrentPackage();
        currentTour = null;
        currentTourPackages.Clear();
    }

    public bool SetCurrentPackage(string packageID)
    {
        // how to handle errors when the package it self is here and it is in the packagesList of the tour
        // and was scanned but no complete package data was found
        currentPackage = data.FindPackageByCode(packageID);

        int packageIndex = currentTourPackages.FindIndex(it => it.id == packageID);
        if (packageIndex != -1)
        {
            Debug.Log("Package scanned: " + packageID);
            currentTourPackages[packageIndex] = (packageID, true);
            return true;
        }
        else
        {
            Debug.Log("Package not found: " + packageID);
            return false;
        }
    }

    public void EndCurrentPackage()
    {
        currentPackage = null;
    }

    // currentUI and nextUI can be null if no objects should be changed after the check
    public bool CheckID(string objectID, CheckIdType type, GameObject currentUI, GameObject nextUI, GameObject errorUI)
    {
        bool success = false;
        switch (type)
        {
            case CheckIdType.login:
                success = Login(objectID);
                break;
            case CheckIdType.tour:
                success = setCurrentTour(Int32.Parse(objectID));
                break;
            case CheckIdType.package:
                success = SetCurrentPackage(objectID);
                break;
        }

        if (success)
        {
            SwitchUI(currentUI, nextUI);
            if (errorUI != null && errorUI.active)
            {
                errorUI.SetActive(false);
            }
        }
        else if (errorUI != null)
        {
            errorUI.SetActive(true);
        }

        return success;
    }

    public void SwitchUI(GameObject currentUI, GameObject nextUI)
    {
        if (currentUI != null)
        {
            currentUI.SetActive(false);
        }

        if (nextUI != null)
        {
            nextUI.SetActive(true);
        }

    }
}
