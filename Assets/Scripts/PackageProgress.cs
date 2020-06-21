using DataProvider;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageProgress : MonoBehaviour
{

    private DataManager manager;

    private int packageCount;

    private Slider progressBar;

    private void Start()
    {
        manager = DataManager.Instance;
        progressBar = gameObject.GetComponent<Slider>();

        packageCount = manager.currentTour.ssccs.Length;

        UpdateProgressBar();
    }

    private void OnEnable()
    {
        UpdateProgressBar();
    }

    public void UpdateProgressBar()
    {
        int finished = 0;

        foreach (var t in manager.currentTour.ssccs)
        {
            if (t.SSCCStatus == 1)
            {
                finished++;
            }
        }

        progressBar.maxValue = packageCount;
        progressBar.value = finished;
    }
}
