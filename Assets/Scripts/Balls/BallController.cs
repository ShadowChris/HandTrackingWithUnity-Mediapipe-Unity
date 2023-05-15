using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position; // ����С��ĳ�ʼλ��
    }

    private void Update()
    {
        if (transform.position.y <= 0.1)
        {
            // ���С���z����С�ڻ����0���ͽ����ƻس�ʼλ��
            transform.position = initialPosition;

            // ����и��壬���ܻ���Ҫֹͣ��ǰ���˶�״̬
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // �����ٶ�
                rb.angularVelocity = Vector3.zero; // ������ٶ�
            }
        }
    }
}
