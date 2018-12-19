using HoloToolkit.Unity;
using HoloToolkit.UX.Progress;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;
using Vuforia;

public class SalaTrackableHandler : MonoBehaviour, ITrackableEventHandler{

    protected TrackableBehaviour mTrackableBehaviour;
    private bool activeAndEstabilized = false;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
                OnTrackingFound();
            }
            else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                     newStatus == TrackableBehaviour.Status.NOT_FOUND)
            {
                Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
                OnTrackingLost();
            }
            else
            {
                // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
                // Vuforia is starting, but tracking has not been lost or found yet
                // Call OnTrackingLost() to hide the augmentations
                OnTrackingLost();
            }
        }

    private void OnTrackingLost()
    {
        if (activeAndEstabilized)
            return;
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    private void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;

        StartCoroutine(CountPosition());
    }

    private IEnumerator CountPosition()
    {
        float progress = 0;
        bool progressOk = false;
        ProgressIndicator.Instance.Open(IndicatorStyleEnum.Prefab, ProgressStyleEnum.ProgressBar, ProgressMessageStyleEnum.None);
        while (mTrackableBehaviour.CurrentStatus == TrackableBehaviour.Status.TRACKED ||
                mTrackableBehaviour.CurrentStatus == TrackableBehaviour.Status.DETECTED ||
                mTrackableBehaviour.CurrentStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            ProgressIndicator.Instance.SetProgress(progress);
            yield return new WaitForSecondsRealtime(0.2f);
            if(progress < 100)
            {
                progress += 10;
            }
            else
            {
                progressOk = true;
                yield break;
            }
        }
        
        ProgressIndicator.Instance.Close();
        if(progressOk)
        {
            //display mensagem ok e separa os objetos
            RemoveChildren();
        }
        else
        {
            //se chegar aqui deumerda
        }
    }

    private void RemoveChildren()
    {
        var child = transform.GetChild(0);
        child.transform.parent = null;
        var anchor = child.EnsureComponent<WorldAnchor>();
        anchor.name = "SalaInovacaoMainAnchor";
    }

    // Use this for initialization
    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }


    // Update is called once per frame

}
