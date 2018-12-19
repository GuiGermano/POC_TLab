using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponto : MonoBehaviour, IInputClickHandler {

    public GameObject positions;
    void Start () {
		
	}
	
	void Update () {
		
	}
public void OnInputClicked(InputClickedEventData eventData)
    {
        switch (eventData.selectedObject.name)
        {
            case "Porto":
                LinhaTrack.Instance.destino = positions.transform.Find("Porto");
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Porto"));
                break;
            case "Favero":
                LinhaTrack.Instance.destino = positions.transform.Find("Favero");
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Favero"));
                break;
            case "Santos":
                LinhaTrack.Instance.destino = positions.transform.Find("Santos");
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Santos"));
                break;
            case "Germano":
                LinhaTrack.Instance.destino = positions.transform.Find("Germano");
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Germano"));
                break;
            case "Suzuki":
                LinhaTrack.Instance.destino = positions.transform.Find("Suzuki");
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Suzuki"));
                break;
            default:
                LinhaTrack.Instance.destino = positions.transform.Find("Eliezer");
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Eliezer"));

                break;
        }
    }
}