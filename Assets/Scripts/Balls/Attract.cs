using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour
{
    public GameObject hand;
    public float attractDistance = 0.3f;
    public bool isAttachedToHand = false;

    private Rigidbody rb;
    private CapsuleCollider Collider;
    
    // ball attach state
    private bool ballIsAttached = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Collider = hand.GetComponent<CapsuleCollider>();
    }

    void Update()
    {

        Vector3 handPos = hand.transform.position;
        Vector3 currPos = this.transform.position;
        Vector3 distance = handPos - currPos;

        print("distance: " + distance.magnitude);


        if (isAttachedToHand && distance.magnitude < attractDistance)
        {
            AttachToHand();
        } else
        {
            DetachFromHand();
        }

    }

    void AttachToHand()
    {
        rb.useGravity = false;
        this.transform.position = hand.transform.position;
        ballIsAttached = true;
    }

    void DetachFromHand()
    {
        rb.useGravity = true;
        ballIsAttached = false;
    }
    
    public bool getBallAttachState()
    {
        return ballIsAttached;
    }
    //Collider
}
