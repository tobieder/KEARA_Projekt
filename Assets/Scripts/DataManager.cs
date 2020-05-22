using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataProvider;

public enum Type { login, tour, package };

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public DataProvider.DataProvider data;
    public UserData currentEmployee = null;

    public TourData currentTour = null;

    private float shiftStartTime = 0.0f;
    private bool clockedIn = false;

    private int simiulationCounter = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public UserData Login(string employeeID)
    {
        if (simiulationCounter == 0)
        {
            simiulationCounter++;
            return null;
        }

        currentEmployee = data.FindUserById(employeeID);

        if (currentEmployee != null)
        {
            Debug.Log(currentEmployee.name + " Logged in successfully");
        }
        else
        {
            Debug.Log("UserId not found: " + employeeID);
        }
        return currentEmployee;
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

    public TourData SetCurrentTour(string tourId)
    {
        if (simiulationCounter == 0)
        {
            simiulationCounter++;
            return null;
        }

        currentTour = data.FindTourById(tourId);

        if (currentTour != null)
        {
            Debug.Log(currentTour.id + " Tour started.");
        }
        else
        {
            Debug.Log("TourID not found: " + tourId);
        }
        return currentTour;
    }

    //EndTour, SetCurrentPackage, EndCurrentPackage

    //Überprüfung wie in BarcodeScan (switchCase)
    void CheckID(string currentID, Type type, GameObject currentUI, GameObject nextUI, GameObject errorUI)
    {
    }

    public void SwitchUI(GameObject currentUI, GameObject nextUI)
    {
        nextUI.SetActive(true);
        currentUI.SetActive(false);
    }
}
