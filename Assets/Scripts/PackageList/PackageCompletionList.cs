﻿using System;
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

    private DataManager manager;

    private int correctPackages = 0;
    private int errorPackages = 0;
    private int additionalPackages = 0;
    private int missingPackages = 0;

    void Awake()
    {
        manager = DataManager.Instance;
        manager.setCurrentTour(Int32.Parse("139149"));

        titelText.text = "Tour " + manager.currentTour.id;
    }

    // Update is called once per frame
    void OnEnable()
    {

        correctPackages = 0;
        errorPackages = 0;
        additionalPackages = 0;
        missingPackages = 0;
        foreach (var t in manager.currentTour.ssccs)
        {
            switch(t.SSCCStatus)
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