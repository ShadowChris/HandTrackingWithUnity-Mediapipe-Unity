using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public float forceMagnitude = 10.0f; // 设定力的大小

    [field: SerializeField] public Quaternion angle;
    public void LaunchBall(bool launch)
    {
        if (launch)
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                // 计算向 z 轴方向上 45 度的力
                Vector3 force = angle * Vector3.forward * forceMagnitude;
                rb.AddForce(force);
            }
        }
    }
}
