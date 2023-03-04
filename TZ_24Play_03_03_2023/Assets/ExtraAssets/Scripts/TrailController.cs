using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    TrailRenderer trail;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        Vector3[] points = new Vector3[trail.positionCount];
        for (int i = 0; i < trail.positionCount; i++)
        {
            points[i] = transform.position;
        }
        trail.SetPositions(points);
    }
}
