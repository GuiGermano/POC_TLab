using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathAgent : Singleton<PathAgent>
{
    public Transform playerPos;
    Transform target;
    public NavMeshAgent navMeshA;
    public LineRenderer track;
    bool destiny;


    void Start()
    {
        track = GetComponentInChildren<LineRenderer>();
        track.startWidth = 0.10f;
        track.endWidth = 0.10f;

        track.enabled = false;
        transform.position = playerPos.position;
        navMeshA = GetComponent<NavMeshAgent>();

    }


    void Update()
    {
        transform.position = playerPos.position;
        if (destiny)
        {
            track.SetPosition(1, target.position);
            track.SetPosition(0, transform.position);
        }

    }

    public IEnumerator VaiPraPosicao(Transform destino)
    {
        target = destino ;
        destiny = true;
        var distancia = (playerPos.position - destino.position).magnitude;
        if (distancia > 0.2f)
        {
            track.enabled = true;
            transform.position = new Vector3(playerPos.position.x, 0.1f, playerPos.position.z);
            track.transform.position = new Vector3(playerPos.position.x, 0.1f, playerPos.position.z);
            navMeshA.baseOffset = 0.1f;
            navMeshA.destination = destino.position;
            yield return null;
        }
        else
        {
            StopAllCoroutines();
                 destiny = false;
        }
       
       
    }
}
