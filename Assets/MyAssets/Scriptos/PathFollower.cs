using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] path;
    public float velocidade = 3f;
    public float reachDist = 0.2f;
    public int currentPoint = 0;

    void Start() { }

    void Update()
    {
        Vector3 dir = new Vector3(path[currentPoint].position.x, 0f, path[currentPoint].position.z) - new Vector3(transform.position.x, 0f, transform.position.z);
        transform.position += dir * Time.deltaTime * velocidade;
        
        transform.forward = path[currentPoint].forward;

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
