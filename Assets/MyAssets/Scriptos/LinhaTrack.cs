using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode()]
public class LinhaTrack : Singleton<LinhaTrack>
{
    public Transform[] points;//0 = player & 1 = target
    public LineRenderer lineRenderer;
    public Transform destino;
    void Start()
    {
        destino = null;
        lineRenderer.positionCount = points.Length;

    }

    void Update()
    {
        if (destino != null)
        {
            lineRenderer.enabled = true;

            points[1] = destino;
            var dist = Vector3.Distance(points[0].position, points[1].position);

            if (dist > 0.2f)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    var posLinha = new Vector3(points[i].position.x, .1f, points[i].position.z);
                    lineRenderer.SetPosition(i, posLinha);
                }
            }
        }
        else
            lineRenderer.enabled = false;
    }
}
