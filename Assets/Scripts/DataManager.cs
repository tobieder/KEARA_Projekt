using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataProvider;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set;}

    public DataProvider.DataProvider data;
    public UserData currentEmployee = null;

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

        if(currentEmployee != null)
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
}
