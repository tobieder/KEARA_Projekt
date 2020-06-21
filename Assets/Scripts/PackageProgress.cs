using DataProvider;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageProgress : MonoBehaviour
{

    private int packageCount;

    private Slider progressBar;

    private void Start()
    {
        progressBar = gameObject.GetComponent<Slider>();

        packageCount = DataManager.Instance.currentTour.ssccs.Length;

        UpdateProgressBar();
    }

    private void OnEnable()
    {
        UpdateProgressBar();
    }

    public void UpdateProgressBar()
    {
        progressBar = gameObject.GetComponent<Slider>();
        int finished = 0;

        if(DataManager.Instance.currentTour.ssccs != null)
        {
            foreach (var t in DataManager.Instance.currentTour.ssccs)
            {
                if (t.SSCCStatus == 1)
                {
                    finished++;
                }
            }
        }
        else
        {
            Debug.LogError("currentTour.sscs == null");
        }

        progressBar.maxValue = packageCount;
        progressBar.value = finished;
    }
}
