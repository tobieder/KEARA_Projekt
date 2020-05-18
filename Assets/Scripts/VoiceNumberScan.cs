using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VoiceNumberScan : MonoBehaviour, IMixedRealityDictationHandler
{
    public TextMeshProUGUI numberInput;
    public GameObject nextUI;

    string number;
    bool bIsRecording;

    private IMixedRealityDictationSystem mrdsDictationSystem;

    public void OnDictationComplete(DictationEventData eventData)
    {
        bIsRecording = false;
        Debug.Log("Dictation complete: " + eventData.DictationResult);
    }

    public void OnDictationError(DictationEventData eventData)
    {
        bIsRecording = false;
        Debug.LogError("Dictation error");
    }

    public void OnDictationHypothesis(DictationEventData eventData)
    {
        Debug.Log("Dictation hypothesis: " + eventData.DictationResult);
    }

    public void OnDictationResult(DictationEventData eventData)
    {
        number = eventData.DictationResult.Trim(" .".ToCharArray());
        Debug.Log("Dictation result: " + eventData.DictationResult);
    }

    private void Start()
    {
        mrdsDictationSystem = (CoreServices.InputSystem as IMixedRealityDataProviderAccess)?.GetDataProvider<IMixedRealityDictationSystem>();
        Debug.Assert(mrdsDictationSystem != null, "No dictation system found. In order to use dictation, add a dictation system like 'Windows Dictation Input Provider' to the Data Providers in the Input System profile");
    }

    public void VoiceCommandNumber()
    {
        StartCoroutine("VoiceInput");
    }

    IEnumerator VoiceInput()
    {
        foreach (Button button in transform.parent.GetComponentsInChildren<Button>())
        {
            button.interactable = false;
        }

        number = "";
        bIsRecording = true;
        mrdsDictationSystem.StartRecording(gameObject, 5f, 3f, 30);
        Debug.Log("Dictation started");

        yield return new WaitUntil(() => !bIsRecording);
        mrdsDictationSystem.StopRecording();
        Debug.Log("Recording finished: " + number);
        numberInput.text = number;

        foreach (Button button in transform.parent.GetComponentsInChildren<Button>())
        {
            button.interactable = true;
        }

        if (nextUI != null)
        {
            nextUI.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
