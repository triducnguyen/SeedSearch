using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]

public class PlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject placedPrefab;

    [SerializeField]
    private GameObject instructions;

    [SerializeField]
    public Camera arCamera;

    [SerializeField]
    private ARRaycastManager aRRaycastManager;
    [SerializeField]
    public RaycastHit hitObject;
    public bool onTouchHold = false;
    public bool onMapTouch = false;
    bool mapLowered = true;
    public GameObject SeedSearchPlane;
    public GameObject debugDemo;
    public Button ButtonUp;
    private GameObject placedObject;
    public GameObject MovementTest;
    public Transform goToTarget, target, target1, target2, target3, target4, target5, target6;
    public GameObject step1, step2, step3, step4, step5, step6;
    public float speed;
    public AudioClip testAudio;
    public bool step1Bool = false;
    public bool testBool = true;
    public AudioController audioController;
    public AudioSource source1;
    public Transform flower1, flower2, flower3, flower4, flower5;
    bool flower1Check = false, flower2Check = false, flower3Check = false, flower4Check = false, flower5Check = false;
    int flowerInt = 0;
    public GameObject nextIdea1;
    public GameObject pollenObj;
    public Transform flyOverPosition, pollenBegin, pollenEnd;
    bool flowerSectionDone = false;
    Quaternion beeRotation;
    public GameObject beeParent;
    public GameObject flower1Pollen, flower2Pollen, flower3Pollen, flower4Pollen, flower5Pollen;
    public bool seedBegin = false;

    public GameObject taptomovebee;
    public GameObject taptomovebee2;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private AudioController Conductor;

    public GameObject PlacedPrefab
    {
        get{
            return placedPrefab;
        }
        set{
            placedPrefab = value;
        }
    }

    private ARRaycastManager arRaycastManager;

    void Start()
    {
        Conductor = GameObject.FindObjectOfType<AudioController>();
    }
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(Input.touchCount > 0)
        {
            //Debug.Log(Input.touchCount);
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touchPosition);
                if(Physics.Raycast(ray, out hitObject))
                {
                    if(hitObject.transform.name.Contains("Flower1") && !flower1Check)
                    {
                        target.position = flower1.position;
                        flower1Check = true;
                        flower1Pollen.SetActive(false);
                        flowerInt++;
                        //step1.gameObject.SetActive(true);
                    }
                    if(hitObject.transform.name.Contains("Flower2") && !flower2Check)
                    {
                        target.position = flower2.position;
                        flower2Check = true;
                        flower2Pollen.SetActive(false);
                        flowerInt++;
                        //step2.gameObject.SetActive(true);
                    }
                    if(hitObject.transform.name.Contains("Flower3") && !flower3Check)
                    {
                        target.position = flower3.position;
                        flower3Check = true;
                        flower3Pollen.SetActive(false);
                        flowerInt++;
                        //step3.gameObject.SetActive(true);
                    }
                    if(hitObject.transform.name.Contains("Flower4") && !flower4Check)
                    {
                        target.position = flower4.position;
                        flower4Check = true;
                        flower4Pollen.SetActive(false);
                        flowerInt++;
                        //step4.SetActive(true);
                    }
                    if(hitObject.transform.name.Contains("Flower5") && !flower5Check)
                    {
                        target.position = flower5.position;
                        flower5Check = true;
                        flower5Pollen.SetActive(false);
                        flowerInt++;
                    }
                    if(flowerInt == 5 && flowerSectionDone == false)
                    {
                        //step1.SetActive(true);
                        nextIdea1.gameObject.SetActive(true);
                        flowerSectionDone = true;
                        Conductor.inset("Pollination 2");
                        taptomovebee.SetActive(false);
                        taptomovebee2.SetActive(true);
                    }
                    if(hitObject.transform.name.Contains("Check2"))
                    {
                        beeParent.transform.rotation = new Quaternion(0f, 40f, 0f, 0f);
                        target.position = flyOverPosition.position;
                        pollenObj.gameObject.SetActive(true);
                        //step2.SetActive(true);
                        taptomovebee2.SetActive(false);
                    }
                    if(hitObject.transform.name.Contains("Check4Button"))
                    {
                        seedBegin = true;
                    }
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                touchPosition = touch.position;
            }
            if(touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
            if(onTouchHold)
            {
                if(hitObject.collider != null)
                {
                }
            }
            if(arRaycastManager.Raycast(touchPosition, hits))
            {
                Pose hitPose = hits[0].pose;

                if(onTouchHold)
                {
                    placedObject.transform.position = hitPose.position;
                }
            }
        }
    }

    IEnumerator MoveFunction(Vector3 newPosition)
    {
        float timeSinceStarted = 0f;
        while (MovementTest.transform.position != newPosition)
        {
            timeSinceStarted += Time.deltaTime;
            MovementTest.transform.position = Vector3.Lerp(MovementTest.transform.position, newPosition, timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (MovementTest.transform.position == newPosition)
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }
}

