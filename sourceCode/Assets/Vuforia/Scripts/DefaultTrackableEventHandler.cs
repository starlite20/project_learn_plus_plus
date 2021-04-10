/*==============================================================================
Copyright (c) 2019 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES
    
    //Game Objects for Controlled Image Recognition
    public GameObject heart, watercycle, jallian, caeser, covid;

    protected TrackableBehaviour mTrackableBehaviour;   // helps find the name of the image detected or lost
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        //Deactivate Code-Based Animated Objects at the Start
        watercycle.SetActive(false);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;
        
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + 
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);

        //The following IF statement checks and finds out which image is detected or lost
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
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

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;
        }


        //Helps identify the respective Image Target and load the corresponding Content
        //Also Helps in tracking data for the purpose of Gamification
        if (mTrackableBehaviour.TrackableName == "watercycle")
        {
            watercycle.SetActive(true);
            monitorActivity.userLearnCounter("WC");
        }
        
        if (mTrackableBehaviour.TrackableName == "jallianwala")
        {
            jallian.SetActive(true);
            monitorActivity.userLearnCounter("JWB");
        }
        
        if (mTrackableBehaviour.TrackableName == "heart")
        {
            heart.SetActive(true);
            monitorActivity.userLearnCounter("HRT");
        }

        if (mTrackableBehaviour.TrackableName == "caeser")
        {
            caeser.SetActive(true);
            monitorActivity.userLearnCounter("CSR");
        }

        if (mTrackableBehaviour.TrackableName == "Coronavirus")
        {
            covid.SetActive(true);
            monitorActivity.userLearnCounter("CVD");
        }
        
    }


    protected virtual void OnTrackingLost()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

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

        //Helps deactivate the animated object when Image Target is not in perspective
        //Also Helps in tracking data for the purpose of Gamification
        if (mTrackableBehaviour.TrackableName == "watercycle")
        {
            watercycle.SetActive(false);
            monitorActivity.userLearnTimeCalc("WC");
        }    
        
        if (mTrackableBehaviour.TrackableName == "jallianwala")
        {
            jallian.SetActive(false);
            monitorActivity.userLearnTimeCalc("JWB");
        }
        
        if (mTrackableBehaviour.TrackableName == "heart")
        {
            heart.SetActive(false);
            monitorActivity.userLearnTimeCalc("HRT");
        }

        if (mTrackableBehaviour.TrackableName == "caeser")
        {
            caeser.SetActive(false);
            monitorActivity.userLearnTimeCalc("CSR");
        }

        if (mTrackableBehaviour.TrackableName == "Coronavirus")
        {
            caeser.SetActive(false);
            monitorActivity.userLearnTimeCalc("CVD");
        }
    }

    #endregion // PROTECTED_METHODS
}
