using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;

    public Transform origin;//player camera
    public Transform destino; // path[i].position 
    public float lineDrawSpeed = 12f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, new Vector3(origin.position.x, origin.position.y - 0.3f, origin.position.z));
        lineRenderer.startWidth = 0.45f;
        lineRenderer.endWidth = 0.45f;
        dist = Vector3.Distance(origin.position, destino.position);
    }

    void Update()
    {
        if (counter > dist)
        {
            counter += 0.1f / lineDrawSpeed;
            float x = Mathf.Lerp(0, dist, counter);
            Vector3 pointA = origin.position;
            Vector3 pointB = destino.position;

            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;
            lineRenderer.SetPosition(1, pointAlongLine);
        }
    }
}
