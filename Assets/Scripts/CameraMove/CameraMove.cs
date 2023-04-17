using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform handTransform;
    public Transform cameraTransform;
    public Transform characterTransform;
    public float moveSpeed = 1.0f;
    public float boundaryThreshold = 0.8f;
    public Vector2 horizontalBoundary = new Vector2(-10, 10); // ˮƽ�ƶ���Χ
    public Vector2 verticalBoundary = new Vector2(-10, 10); // ��ֱ�ƶ���Χ
    public bool isEnabled = true; // ���ƽű��Ƿ�����

    private Camera _camera;
    private float _screenWidth;
    private float _screenHeight;
    private Vector3 _initialCharacterPosition; // ��ɫ�ĳ�ʼλ��

    void Start()
    {
        _camera = cameraTransform.GetComponent<Camera>();
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        _initialCharacterPosition = characterTransform.position;
    }

    void Update()
    {
        if (!isEnabled) return; // ����ű�δ���ã���ֱ�ӷ��أ���ִ�к�������

        Vector3 screenPos = _camera.WorldToScreenPoint(handTransform.position);

        Vector3 cameraMoveDirection = Vector3.zero;

        // ����ֲ��Ƿ񿿽���Ļ���ұ߽�
        if (screenPos.x < _screenWidth * (1 - boundaryThreshold) || screenPos.x > _screenWidth * boundaryThreshold)
        {
            // ��������ͷ�ƶ��ķ���
            float moveDirectionX = screenPos.x < _screenWidth * (1 - boundaryThreshold) ? -1 : 1;

            // ��������ͷ�ƶ�����
            cameraMoveDirection += cameraTransform.right * moveSpeed * moveDirectionX * Time.deltaTime;
        }

        // ����ֲ��Ƿ񿿽���Ļ���±߽�
        if (screenPos.y < _screenHeight * (1 - boundaryThreshold) || screenPos.y > _screenHeight * boundaryThreshold)
        {
            // ��������ͷ�ƶ��ķ���
            float moveDirectionY = screenPos.y < _screenHeight * (1 - boundaryThreshold) ? -1 : 1;

            // ��������ͷ�ƶ�����
            cameraMoveDirection += cameraTransform.up * moveSpeed * moveDirectionY * Time.deltaTime;
        }

        // ���½�ɫλ��
        Vector3 newCharacterPosition = characterTransform.position + cameraMoveDirection;

        // ���ƽ�ɫ�ڱ߽����ƶ�
        newCharacterPosition.x = Mathf.Clamp(newCharacterPosition.x, _initialCharacterPosition.x + horizontalBoundary.x, _initialCharacterPosition.x + horizontalBoundary.y);
        newCharacterPosition.y = Mathf.Clamp(newCharacterPosition.y, _initialCharacterPosition.y + verticalBoundary.x, _initialCharacterPosition.y + verticalBoundary.y);

        // ��������ͷ�ͽ�ɫ��λ��
        Vector3 deltaPosition = newCharacterPosition - characterTransform.position;
        cameraTransform.position += deltaPosition;
        characterTransform.position = newCharacterPosition;
    }
}
