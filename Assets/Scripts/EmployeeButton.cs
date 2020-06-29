using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeButton : MonoBehaviour
{
    public GameObject logoutScreen;
    public GameObject[] gameobjectsToDisable;

    public void ButtonPressed()
    {
       foreach(GameObject go in gameobjectsToDisable)
       {
            go.SetActive(false);
       }

       logoutScreen.SetActive(true);
    }
}
