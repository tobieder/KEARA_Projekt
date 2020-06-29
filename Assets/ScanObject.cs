using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanObject : MonoBehaviour
{
    public void startMove(Transform startPos, Transform endPos, float duration)
    {
        StartCoroutine(MoveObject(startPos, endPos, duration));
    }

    public IEnumerator MoveObject(Transform startPos, Transform endPos, float duration)
    {
        float t = 0.0f;

        while (t < 1.0f)
        {
            t += Time.deltaTime / duration;

            transform.position = Vector3.Lerp(startPos.position, endPos.position, t);
            yield return new WaitForUpdate();
        }
    }
}
