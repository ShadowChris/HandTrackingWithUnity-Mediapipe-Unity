using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public float forceMagnitude = 10.0f; // �趨���Ĵ�С

    [field: SerializeField] public Quaternion angle;
    public void LaunchBall(bool launch)
    {
        if (launch)
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                // ������ z �᷽���� 45 �ȵ���
                Vector3 force = angle * Vector3.forward * forceMagnitude;
                rb.AddForce(force);
            }
        }
    }
}
