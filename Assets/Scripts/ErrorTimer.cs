using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorTimer : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(deactivate());
    }

    IEnumerator deactivate()
    {
        yield return new WaitForSeconds(2);
        transform.gameObject.SetActive(false);
    }
}
