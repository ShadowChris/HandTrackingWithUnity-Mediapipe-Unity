using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform handTransform;
    public Transform cameraTransform;
    public Transform characterTransform;
    public float moveSpeed = 1.0f;
    public float boundaryThreshold = 0.8f;
    public Vector2 horizontalBoundary = new Vector2(-10, 10); // 水平移动范围
    public Vector2 verticalBoundary = new Vector2(-10, 10); // 垂直移动范围
    public bool isEnabled = true; // 控制脚本是否启用

    private Camera _camera;
    private float _screenWidth;
    private float _screenHeight;
    private Vector3 _initialCharacterPosition; // 角色的初始位置

    void Start()
    {
        _camera = cameraTransform.GetComponent<Camera>();
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        _initialCharacterPosition = characterTransform.position;
    }

    void Update()
    {
        if (!isEnabled) return; // 如果脚本未启用，则直接返回，不执行后续代码

        Vector3 screenPos = _camera.WorldToScreenPoint(handTransform.position);

        Vector3 cameraMoveDirection = Vector3.zero;

        // 检查手部是否靠近屏幕左右边界
        if (screenPos.x < _screenWidth * (1 - boundaryThreshold) || screenPos.x > _screenWidth * boundaryThreshold)
        {
            // 计算摄像头移动的方向
            float moveDirectionX = screenPos.x < _screenWidth * (1 - boundaryThreshold) ? -1 : 1;

            // 计算摄像头移动向量
            cameraMoveDirection += cameraTransform.right * moveSpeed * moveDirectionX * Time.deltaTime;
        }

        // 检查手部是否靠近屏幕上下边界
        if (screenPos.y < _screenHeight * (1 - boundaryThreshold) || screenPos.y > _screenHeight * boundaryThreshold)
        {
            // 计算摄像头移动的方向
            float moveDirectionY = screenPos.y < _screenHeight * (1 - boundaryThreshold) ? -1 : 1;

            // 计算摄像头移动向量
            cameraMoveDirection += cameraTransform.up * moveSpeed * moveDirectionY * Time.deltaTime;
        }

        // 更新角色位置
        Vector3 newCharacterPosition = characterTransform.position + cameraMoveDirection;

        // 限制角色在边界内移动
        newCharacterPosition.x = Mathf.Clamp(newCharacterPosition.x, _initialCharacterPosition.x + horizontalBoundary.x, _initialCharacterPosition.x + horizontalBoundary.y);
        newCharacterPosition.y = Mathf.Clamp(newCharacterPosition.y, _initialCharacterPosition.y + verticalBoundary.x, _initialCharacterPosition.y + verticalBoundary.y);

        // 更新摄像头和角色的位置
        Vector3 deltaPosition = newCharacterPosition - characterTransform.position;
        cameraTransform.position += deltaPosition;
        characterTransform.position = newCharacterPosition;
    }
}
