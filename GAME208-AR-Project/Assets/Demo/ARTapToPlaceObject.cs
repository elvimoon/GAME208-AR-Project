using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;
using System;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;

    private Pose placementPose; //represent position and position in space of a 3d point
    private ARRaycastManager arOrigin;
    private bool placementPoseIsValid = false;

    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        //check world around us and where camera is pointing to identify if position available to place object
        UpdatePlacementPose();
        //update our indicator visual position every frame
        UpdatePlacementIndicator();

        //check if indicator is active and if user has tapped the screen
        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        Instantiate(objectToPlace, placementPose.position, objectToPlace.transform.rotation);
    }

    private void UpdatePlacementIndicator()
    {
        //if plane exists, then we will see the indicator appear on camera, otherwise it will not appear
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);

            //control position and rotation of indicator
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        //find center of screen
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0.0f));
        //represent any point in physical space where ray hits physical surface
        var hits = new List<ARRaycastHit>();
        //after arOrigin called, will either get empty hit list = no flat plane in front of camera, otherwise there will be a list
        //to keep track of outcome, will create placementPoseIsValid bool
        arOrigin.Raycast(screenCenter, hits, TrackableType.Planes);

        //only valid if plane exists, aka hits must be 1 or more
        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            //acts as arrow describing direction camera facing along x,y,z axis
            var cameraForward = Camera.current.transform.forward;

            //dont care how much camera points toward sky or ground, only the bearing
            //this setup will give bearing as though y was perfectly vertical
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

            placementPose.rotation = Quaternion.LookRotation(cameraBearing);

        }
    }

}
