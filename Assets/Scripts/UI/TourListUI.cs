using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourListUI : MonoBehaviour
{
    public GameObject extendedTourList;
    public GameObject contractedTourList;

    public void ExtendTourList()
    {
        extendedTourList.SetActive(true);
        contractedTourList.SetActive(false);
    }

    public void ContractTourList()
    {
        contractedTourList.SetActive(true);
        extendedTourList.SetActive(false);
    }
}
