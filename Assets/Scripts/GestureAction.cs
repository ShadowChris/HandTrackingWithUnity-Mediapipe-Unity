using landmarktest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestureAction : MonoBehaviour
{
    public GameObject rightHand; // Drag the RightHand object with the HandTracking script attached here in the Inspector.
    private HandTracking handTrackingScript;
    public string currentGesture;

    // 右上角实时显示手势类别
    public Text gestureTypeLabel;

    void Start()
    {
        handTrackingScript = rightHand.GetComponent<HandTracking>();
    }

    void Update()
    {
        currentGesture = handTrackingScript.gestureLabel;

        gestureTypeLabel.text = currentGesture;

        // Check the gesture label and perform actions accordingly
        if (currentGesture == "specificGesture1")
        {
            // Perform actions for specificGesture1, like attract sphere to hand
        }
        else if (currentGesture == "specificGesture2")
        {
            // Perform actions for specificGesture2, like trigger click functionality
        }
        else if (currentGesture == "specificGesture3")
        {
            // Perform actions for specificGesture3, like trigger camera movement
        }
    }
}
