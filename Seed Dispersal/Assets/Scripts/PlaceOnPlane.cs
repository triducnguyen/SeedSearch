using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private ARPlaneManager aRPlaneManager;
    
    private bool Islandspawn = false;
    private float Islandheight;
    public float heightscalar;

    public GameObject Island;


    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public GameObject beginbutton;

    private bool begin = false;

    private void Awake(){
        raycastManager = GetComponent<ARRaycastManager>();
        Island.SetActive(false);
    }
    void Start(){
        
        aRPlaneManager = GetComponent<ARPlaneManager>();
        beginbutton.SetActive(false);
    }
    bool TryGetTouchPosition(out Vector2 touchPosition){
        if(Input.touchCount > 0){
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    private void Update(){
        if(Islandspawn == false && beginbutton.activeInHierarchy == false){
            if(!TryGetTouchPosition(out Vector2 touchPosition)){
                return;
            }
            
            if(raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon)){
                var hitPose = s_Hits[0].pose;
                Islandheight = (this.transform.position.y - hitPose.position.y) * heightscalar;
                Island.SetActive(true);
                Island.transform.position = hitPose.position + new Vector3(0,Islandheight,0);
                Islandspawn = true;
                beginbutton.SetActive(true);
                toggleplanedetection();
            }
        }
        

    }

    private void toggleplanedetection(){
        aRPlaneManager.enabled = !aRPlaneManager.enabled;

        foreach(ARPlane plane in aRPlaneManager.trackables){
            plane.gameObject.SetActive(aRPlaneManager.enabled);
        }        
    }
}
