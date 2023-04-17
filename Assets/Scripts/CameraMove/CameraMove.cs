using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform handTransform; // �����ֲ�׷��������Դ�������ֲ�ģ�͵� Transform ���
    public Transform cameraTransform; // ����ͷ�� Transform ���
    public float moveSpeed = 1.0f; // ����ͷ�ƶ��ٶ�
    public float boundaryThreshold = 0.8f; // �߽���ֵ����Χ 0-1������ 0.8 ��ʾ�ֲ�λ�õ�����Ļ��ȵ� 80% ʱ�����ƶ�

    private Camera _camera;
    private float _screenWidth;
    private float _screenHeight;

    void Start()
    {
        _camera = cameraTransform.GetComponent<Camera>();
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
    }

    void Update()
    {
        Vector3 screenPos = _camera.WorldToScreenPoint(handTransform.position);

        // ����ֲ��Ƿ񿿽���Ļ���ұ߽�
        if (screenPos.x < _screenWidth * (1 - boundaryThreshold) || screenPos.x > _screenWidth * boundaryThreshold)
        {
            // ��������ͷ�ƶ��ķ���
            float moveDirectionX = screenPos.x < _screenWidth * (1 - boundaryThreshold) ? -1 : 1;

            // �ƶ�����ͷ
            cameraTransform.position += cameraTransform.right * moveSpeed * moveDirectionX * Time.deltaTime;
        }

        // ����ֲ��Ƿ񿿽���Ļ���±߽�
        if (screenPos.y < _screenHeight * (1 - boundaryThreshold) || screenPos.y > _screenHeight * boundaryThreshold)
        {
            // ��������ͷ�ƶ��ķ���
            float moveDirectionY = screenPos.y < _screenHeight * (1 - boundaryThreshold) ? -1 : 1;

            // �ƶ�����ͷ
            cameraTransform.position += cameraTransform.up * moveSpeed * moveDirectionY * Time.deltaTime;

        }
    }
}
