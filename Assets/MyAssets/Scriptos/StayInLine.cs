using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StayInLine : Singleton<StayInLine>
{
    public NavMeshAgent agent;
    bool isMoving;
    Transform alvo;
    private void OnEnable()    {        agent = transform.GetComponent<NavMeshAgent>();            }
    void Start() { }

    void Update()
    {
    
        if (isMoving)
        {
            if ((transform.position - alvo.position).magnitude <= 0.3f)
            {
                transform.position = new Vector3(GameObject.Find("MixedRealityCamera").transform.position.x, 0.02f, GameObject.Find("MixedRealityCamera").transform.position.z);
                isMoving = false;
                SetAgentTarget(null);
            }
        }
        else
        {
            transform.position = new Vector3(GameObject.Find("MixedRealityCamera").transform.position.x, 0.02f, GameObject.Find("MixedRealityCamera").transform.position.z);
            GetComponent<TrailRenderer>().time = 0;
        }
        
    }
    public void SetAgentTarget(Transform target)
    {
        if (target != null)
        {
            GetComponent<TrailRenderer>().time = Mathf.Infinity;

            transform.position = new Vector3(GameObject.Find("MixedRealityCamera").transform.position.x, 0.02f, GameObject.Find("MixedRealityCamera").transform.position.z);
            agent.destination = target.position;
            alvo = target;
            isMoving = true;
        }
    }
}
