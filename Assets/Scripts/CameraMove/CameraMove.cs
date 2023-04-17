using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform handTransform; // 您的手部追踪数据来源，例如手部模型的 Transform 组件
    public Transform cameraTransform; // 摄像头的 Transform 组件
    public float moveSpeed = 1.0f; // 摄像头移动速度
    public float boundaryThreshold = 0.8f; // 边界阈值，范围 0-1，例如 0.8 表示手部位置到达屏幕宽度的 80% 时触发移动

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

        // 检查手部是否靠近屏幕左右边界
        if (screenPos.x < _screenWidth * (1 - boundaryThreshold) || screenPos.x > _screenWidth * boundaryThreshold)
        {
            // 计算摄像头移动的方向
            float moveDirectionX = screenPos.x < _screenWidth * (1 - boundaryThreshold) ? -1 : 1;

            // 移动摄像头
            cameraTransform.position += cameraTransform.right * moveSpeed * moveDirectionX * Time.deltaTime;
        }

        // 检查手部是否靠近屏幕上下边界
        if (screenPos.y < _screenHeight * (1 - boundaryThreshold) || screenPos.y > _screenHeight * boundaryThreshold)
        {
            // 计算摄像头移动的方向
            float moveDirectionY = screenPos.y < _screenHeight * (1 - boundaryThreshold) ? -1 : 1;

            // 移动摄像头
            cameraTransform.position += cameraTransform.up * moveSpeed * moveDirectionY * Time.deltaTime;

        }
    }
}
