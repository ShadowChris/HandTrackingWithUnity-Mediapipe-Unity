using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionController : MonoBehaviour
{

    public GameObject GestureTypeObj;
    public GameObject GestureTypeForTestObj;
    public Attract SphereAttract;
    public BallLauncher SphereBallLauncher;

    // 如果开启此模式，小球会一直触发吸附，并且当吸附时，GestureTypeForTest会变成grasp
    public bool isForceAttracted;
    public bool launchBall = false;

    public int throwLoopTimes = 50;
    public float throwWaitMilliTime = 2f;

    private Text GestureType;
    private Text GestureTypeForTest;

    private bool isCoroutineRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        GestureType = GestureTypeObj.GetComponent<Text>();
        GestureTypeForTest = GestureTypeForTestObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // 强制开启吸附模式
        if (isForceAttracted)
        {
            SphereAttract.isAttachedToHand = true;
        } else
        {
            SphereAttract.isAttachedToHand = false;
        }

        // 检测小球吸附状态，改变label
        if (isForceAttracted && SphereAttract.getBallAttachState())
        {
            GestureTypeObj.SetActive(false);
            GestureTypeForTestObj.SetActive(true);
            GestureTypeForTest.text = "grasp";
        } else
        {
            GestureTypeObj.SetActive(true);
            GestureTypeForTestObj.SetActive(false);
        }

        if (launchBall == true)
        {
            SphereBallLauncher.LaunchBall(true);

            if (!isCoroutineRunning)
            {
                StartCoroutine(ThrowCoroutine());
            }
            
            launchBall = false;
        }


    }

    IEnumerator ThrowCoroutine()
    {
        isCoroutineRunning = true;

        for (int i = 0; i < throwLoopTimes; i++)
        {
            GestureType.text = "throw";
            yield return new WaitForSecondsRealtime(throwWaitMilliTime * 0.001f); // 等待2毫秒
        }

        isCoroutineRunning = false;
    }
}
