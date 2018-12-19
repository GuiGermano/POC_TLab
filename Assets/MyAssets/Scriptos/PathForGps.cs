using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathForGps : MonoBehaviour
{

    public Transform[] path;
    public float velocidade = 3f;
    public float reachDist = 0.2f;
    public int currentPoint = 0;

    private LineRenderer lineRenderer;
    private float dSeparacao;

    public Transform origin;//player camera
    public Transform destino; // path[i].position 
    private void Awake()
    {
        destino = path[currentPoint];
    }
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        dSeparacao = 0.2f;
        lineRenderer.startWidth = 0.45f;
        lineRenderer.endWidth = 0.45f;

    }

    void Update()
    {
        var dist = (transform.position - path[currentPoint].position).magnitude;
        if (dist > dSeparacao)
        {
            lineRenderer.SetPosition(1, path[currentPoint].position);
            lineRenderer.SetPosition(0, transform.position);
            destino = path[currentPoint];
        }

        Vector3 dir = new Vector3(path[currentPoint].position.x, 0f, path[currentPoint].position.z) - new Vector3(transform.position.x, 0f, transform.position.z);
      
        if (dir.magnitude <= reachDist)
        {
            currentPoint++;
        }
        if (currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }
}
