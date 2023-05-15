using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position; // 储存小球的初始位置
    }

    private void Update()
    {
        if (transform.position.y <= 0.1)
        {
            // 如果小球的z坐标小于或等于0，就将它移回初始位置
            transform.position = initialPosition;

            // 如果有刚体，可能还需要停止当前的运动状态
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // 清零速度
                rb.angularVelocity = Vector3.zero; // 清零角速度
            }
        }
    }
}
