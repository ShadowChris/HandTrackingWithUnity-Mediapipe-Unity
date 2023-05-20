using landmarktest;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform handTransform;
    public Transform cameraTransform;
    public Transform characterTransform;
    public HandTracking handTracking;
    public float moveSpeed = 1.0f;
    public float boundaryThreshold = 0.8f;
    public Vector2 horizontalBoundary = new Vector2(-10, 10);
    public Vector2 verticalBoundary = new Vector2(-10, 10);
    public bool isEnabled = true;

    private Camera _camera;
    private float _screenWidth;
    private float _screenHeight;
    private Vector3 _initialCharacterPosition;

    void Start()
    {
        _camera = cameraTransform.GetComponent<Camera>();
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        _initialCharacterPosition = characterTransform.position;
    }

    void Update()
    {
        if (!isEnabled) return;

        Vector3 screenPos = _camera.WorldToScreenPoint(handTransform.position);

        Vector3 cameraMoveDirection = Vector3.zero;
        string gestureLabel = handTracking.gestureLabel;

        // ������Ʊ�ǩ��"left"�����ֲ�������Ļ��߽�
        if (gestureLabel == "left" && screenPos.x < _screenWidth * (1 - boundaryThreshold))
        {
            cameraMoveDirection += cameraTransform.right * moveSpeed * -1 * Time.deltaTime;
        }

        // ������Ʊ�ǩ��"right"�����ֲ�������Ļ�ұ߽�
        if (gestureLabel == "right" && screenPos.x > _screenWidth * boundaryThreshold)
        {
            cameraMoveDirection += cameraTransform.right * moveSpeed * Time.deltaTime;
        }

        // ������Ʊ�ǩ��"up"�����ֲ�������Ļ�ϱ߽�
        if (gestureLabel == "up" && screenPos.y > _screenHeight * boundaryThreshold)
        {
            cameraMoveDirection += cameraTransform.up * moveSpeed * Time.deltaTime;
        }

        // ������Ʊ�ǩ��"down"�����ֲ�������Ļ�±߽�
        if (gestureLabel == "down" && screenPos.y < _screenHeight * (1 - boundaryThreshold))
        {
            cameraMoveDirection += cameraTransform.up * moveSpeed * -1 * Time.deltaTime;
        }

        Vector3 newCharacterPosition = characterTransform.position + cameraMoveDirection;
        newCharacterPosition.x = Mathf.Clamp(newCharacterPosition.x, _initialCharacterPosition.x + horizontalBoundary.x, _initialCharacterPosition.x + horizontalBoundary.y);
        newCharacterPosition.y = Mathf.Clamp(newCharacterPosition.y, _initialCharacterPosition.y + verticalBoundary.x, _initialCharacterPosition.y + verticalBoundary.y);

        // Maintain the same z position
        newCharacterPosition.z = _initialCharacterPosition.z;

        Vector3 deltaPosition = newCharacterPosition - characterTransform.position;
        cameraTransform.position += deltaPosition;
        characterTransform.position = newCharacterPosition;
    }
}
