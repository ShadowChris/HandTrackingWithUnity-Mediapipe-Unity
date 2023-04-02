using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractWithForce : MonoBehaviour
{
    public GameObject hand;
    public float attractDistance = 0.3f;
    public float force = 500f;

    private Rigidbody rb;
    private bool isAttracted;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 handPos = hand.transform.position;
        Vector3 currPos = this.transform.position;
        Vector3 distance = handPos - currPos;

        print("distance: " + distance.magnitude);
        if (distance.magnitude < attractDistance)
        {   
            // 吸引之后关掉重力
            if (!isAttracted)
            {
                isAttracted = true;
                rb.useGravity = false;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }
            rb.AddForce(distance * force);
        }
        else
        {
            if (isAttracted)
            {
                isAttracted = false;
                rb.useGravity = true;
                rb.interpolation = RigidbodyInterpolation.None;
            }
        }
    }
}
