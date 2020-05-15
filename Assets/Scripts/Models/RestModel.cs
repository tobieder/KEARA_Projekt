using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public sealed class RestModel : MonoBehaviour
{
    private static readonly RestModel instance = new RestModel();

    static RestModel()
    {

    }

    private RestModel()
    {
        
    }

    public static RestModel Instance
    {
        get
        {
            return instance;
        }
    }

    public Employee logInEmployee(string employeeID)
    {
        // API requests should go here

        TextAsset employeeJson = Resources.Load("employees") as TextAsset;

        if (employeeJson != null)
        {
            Employees employees = JsonUtility.FromJson<Employees>(employeeJson.text);
            Employee[] employeesList = employees.employees;

            if (employees != null && employeesList.Length != 0)
            {
                for(int i = 0; i < employeesList.Length; i++)
                {
                    if(employeesList[i].ID == employeeID)
                    {
                        return employeesList[i];
                    }
                }
                return null;
            }
            else
            {
                Debug.LogError("parsing employees list failed");
                return null;
            }

        }
        else
        {
            Debug.LogError("employee asset not found");
            return null;
        }
        
    }
}

