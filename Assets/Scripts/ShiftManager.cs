using UnityEngine;

public class ShiftManager : MonoBehaviour
{
    public void ClockIn()
    {
        DataManager.Instance.ClockIn();
    }

    public void ClockOut()
    {
        DataManager.Instance.ClockOut();
    }

    public void LogoutCurrentUser()
    {
        DataManager.Instance.Logout();
    }
}
