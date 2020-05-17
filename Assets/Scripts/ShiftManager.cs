using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftManager : MonoBehaviour
{
    public void ClockIn()
    {
        DataManager.Instance.ClockIn();
    }

    public void LogoutCurrentUser()
    {
        DataManager.Instance.Logout();
    }
}
