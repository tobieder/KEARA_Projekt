using DataProvider;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetDestinationPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI destination;

    private void OnEnable()
    {
        destination.text = DataManager.Instance.currentPackage.destinationLane.designation;
    }
}
