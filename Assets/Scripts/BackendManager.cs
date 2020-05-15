using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BackendManager
{
    private static readonly BackendManager instance = new BackendManager();
    public Employee currentEmployee = null;

    private int simiulationCounter = 0;

    static BackendManager()
    {

    }

    private BackendManager()
    {

    }

    public static BackendManager Instance
    {
        get
        {
            return instance;
        }
    }

    private RestModel restModel = RestModel.Instance;


    public Employee login(string employeeID)
    {
        if (simiulationCounter == 0)
        {
            simiulationCounter++;
            return null;
        }

        currentEmployee = restModel.logInEmployee(employeeID);
        return currentEmployee;
    }
}
