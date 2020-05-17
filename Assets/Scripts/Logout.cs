using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logout : MonoBehaviour
{

    public void LogoutCurrentUser()
    {
        //Debug.Log(DataManager.Instance.currentEmployee.name);
        DataManager.Instance.Logout();
    }
}
