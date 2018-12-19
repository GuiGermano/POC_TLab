using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPonto : MonoBehaviour, IInputClickHandler
{

    public GameObject positions;
    public GameObject TrailCube;
    void Start()
    {

    }

    void Update()
    {

    }
    public void OnInputClicked(InputClickedEventData eventData)
    {//posicao inicial == sempre a camera !
        //chegou ao ponto, voltar a posicao da camera!
        
        switch (eventData.selectedObject.name)
        {
            case "Porto":
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Porto"));
                break;
            case "Favero":
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Favero"));
                break;
            case "Santos":
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Santos"));
                break;
            case "Germano":
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Germano"));
                break;
            case "Suzuki":
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Suzuki"));
                break;
            case "ArmarioCafe":
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("ArmarioCafe"));
                break;
            default:
                StayInLine.Instance.SetAgentTarget(positions.transform.Find("Eliezer"));

                break;
        }
    }
}