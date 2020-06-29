using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAssets : MonoBehaviour
{
    public float timeToReachTarget;

    public Transform startPosition;
    public Transform endPosition;

    private float t;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, t);

        if(Vector3.Distance(transform.position, endPosition.position) < 0.1)
        {
            Reset();
        }
    }

    void SwitchStartEnd()
    {
        Vector3 save = startPosition.position;
        startPosition = endPosition;
        endPosition.position = save;
    }

    private void Reset()
    {
        transform.position = startPosition.position;
        t = 0;
    }

    public void SetDestination(Vector3 newDestination, float time)
    {
        t = 0;
        startPosition.position = transform.position;
        timeToReachTarget = time;
        endPosition.position = newDestination;
    }
}
