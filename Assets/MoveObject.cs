using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;


public class MoveObject : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(MoveGO());
        }
        if(Input.GetKeyDown(KeyCode.L))
        {

        }
    }

    IEnumerator MoveGO()
    {
        float t = 0.0f;

        while (t < 2.0f)
        {
            t += Time.deltaTime / 1.0f;
            transform.position = Vector3.Lerp(startPos.position, endPos.position, t);

            yield return new WaitForUpdate();
        }

        yield return null;
    }

    IEnumerator Transparancy()
    {
        float t = 1.0f;

        while (t > 0.0f)
        {
            t -= Time.deltaTime / 1.0f;

            foreach (Material m in gameObject.GetComponent<MeshRenderer>().materials)
            {
                Color c = m.color;
                c.a = t;
                m.color = c;
            }

            yield return new WaitForUpdate();
        }

        yield return null;
    }
}
