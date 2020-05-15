using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Employee
{
    public string name;   
    public string ID;      
}

[System.Serializable]
public class Employees
{
    public Employee[] employees;

    public int Length()
    {
        return employees.Length;
    }
}
