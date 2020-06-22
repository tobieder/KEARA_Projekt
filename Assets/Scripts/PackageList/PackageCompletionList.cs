using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataProvider;
using TMPro;

public class PackageCompletionList : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI correctText;

    [SerializeField]
    private TextMeshProUGUI errorText;

    [SerializeField]
    private TextMeshProUGUI additionalText;

    [SerializeField]
    private TextMeshProUGUI missingText;

    [SerializeField]
    private TextMeshProUGUI titelText;

    private int correctPackages = 0;
    private int errorPackages = 0;
    private int additionalPackages = 0;
    private int missingPackages = 0;

    void Start()
    {
        //---------------- DEVELOPMENT OPTION -----------------
        //DataManager.Instance.setCurrentTour(139149);
        //-----------------------------------------------------

        titelText.text = "Tour " + DataManager.Instance.currentTour.id;

        SetButtonLabels();
    }

    // Update is called once per frame
    void OnEnable()
    {
        SetButtonLabels();
    }

    void SetButtonLabels()
    {
        if(DataManager.Instance.currentTour.ssccs != null)
        {
            correctPackages = 0;
            errorPackages = 0;
            additionalPackages = 0;
            missingPackages = 0;
            foreach (var t in DataManager.Instance.currentTour.ssccs)
            {
                switch (t.SSCCStatus)
                {
                    case 0:
                        missingPackages++;
                        break;
                    case 1:
                        correctPackages++;
                        break;
                    case 2:
                        errorPackages++;
                        break;
                    case 3:
                        additionalPackages++;
                        break;
                }
            }
            correctText.text = correctPackages.ToString();
            errorText.text = errorPackages.ToString();
            missingText.text = missingPackages.ToString();
            additionalText.text = additionalPackages.ToString();
        }

    }
}
