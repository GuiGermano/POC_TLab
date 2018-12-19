using HoloToolkit.Unity.Buttons;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode()]
public class ButtonNames : MonoBehaviour
{ 
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var label = transform.GetChild(i).gameObject.GetComponentInChildren<TextMesh>();
            label.name = transform.GetChild(i).name;
            label.text = transform.GetChild(i).name;
            

        }
    }

    void Update()
    {

    }
}
