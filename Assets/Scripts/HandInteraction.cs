using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; // ����UnityEngine.Events�����ռ���ʹ��UnityEvent

public class HandInteraction : MonoBehaviour
{
    public Camera mainCamera; // ָ��������ͷ
    public Button targetButton; // ָ��Ҫ��֮�����İ�ť
    public float interactionTime = 1f; // �ڱ༭���б�¶��ά��ʱ��
    public GameObject finger;

    private float _timer = 0f; // ��ʱ��
    private bool _isCounting = false; // �Ƿ����ڼ�ʱ
    public Image progressCircle; // �ڽű�����Ӷ�ProgressCircle������

    void Update()
    {
        // ��ȡ��ָλ����Ϣ
        Vector3 fingerPosition = finger.transform.position;

        // ����ָλ�ô���������ת��Ϊ��Ļ����
        Vector3 fingerScreenPosition = mainCamera.WorldToScreenPoint(fingerPosition);

        // ����Ƿ����㽻������
        if (IsFingerOnButtonLine(fingerScreenPosition, targetButton))
        {
            // ���������������ʼ��ʱ
            _isCounting = true;
        }
        else
        {
            // ���������������ֹͣ��ʱ�����ü�ʱ��
            _isCounting = false;
            _timer = 0f;
        }

        // ������ڼ�ʱ�����¼�ʱ��
        if (_isCounting)
        {
            _timer += Time.deltaTime;
            // ���½���Ȧ�������
            progressCircle.fillAmount = Mathf.Clamp01(_timer / interactionTime);
            // ����ﵽָ��ʱ�䣬������ť��������ü�ʱ��
            if (_timer >= interactionTime)
            {
                targetButton.onClick.Invoke();
                _timer = 0f;
                progressCircle.fillAmount = 0f; // ���ý���Ȧ�����
            }
        }
        else
        {
            progressCircle.fillAmount = 0f; // ���ý���Ȧ�����
        }
    }


    private bool IsFingerOnButtonLine(Vector3 fingerScreenPosition, Button button)
    {
        // ��ȡ��ť����Ļ��������
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        Rect buttonRect = rectTransform.rect;

        // ������ͷ��Ļλ����Ϊ�ο���
        Vector3 cameraScreenPosition = mainCamera.WorldToScreenPoint(Vector3.zero);

        // ������ָ������ͷ��Ļλ��֮��ķ�������
        Vector3 direction = (fingerScreenPosition - cameraScreenPosition).normalized;

        // �ط�����������һ������
        Ray ray = new Ray(cameraScreenPosition, direction);
        RaycastHit hit;

        // ��������Ƿ��밴ť�����ཻ������ཻ����˵����ָ������ͷ��Ļ����Ͱ�ť����һ���ߡ�
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, fingerScreenPosition, mainCamera))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}