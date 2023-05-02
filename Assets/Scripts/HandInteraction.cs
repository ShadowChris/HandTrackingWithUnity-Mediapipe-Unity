using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; // 导入UnityEngine.Events命名空间以使用UnityEvent

public class HandInteraction : MonoBehaviour
{
    public Camera mainCamera; // 指定主摄像头
    public Button targetButton; // 指定要与之交互的按钮
    public float interactionTime = 1f; // 在编辑器中暴露的维持时间
    public GameObject finger;

    private float _timer = 0f; // 计时器
    private bool _isCounting = false; // 是否正在计时
    public Image progressCircle; // 在脚本中添加对ProgressCircle的引用

    void Update()
    {
        // 获取手指位置信息
        Vector3 fingerPosition = finger.transform.position;

        // 将手指位置从世界坐标转换为屏幕坐标
        Vector3 fingerScreenPosition = mainCamera.WorldToScreenPoint(fingerPosition);

        // 检查是否满足交互条件
        if (IsFingerOnButtonLine(fingerScreenPosition, targetButton))
        {
            // 如果满足条件，开始计时
            _isCounting = true;
        }
        else
        {
            // 如果不满足条件，停止计时并重置计时器
            _isCounting = false;
            _timer = 0f;
        }

        // 如果正在计时，更新计时器
        if (_isCounting)
        {
            _timer += Time.deltaTime;
            // 更新进度圈的填充量
            progressCircle.fillAmount = Mathf.Clamp01(_timer / interactionTime);
            // 如果达到指定时间，触发按钮点击并重置计时器
            if (_timer >= interactionTime)
            {
                targetButton.onClick.Invoke();
                _timer = 0f;
                progressCircle.fillAmount = 0f; // 重置进度圈填充量
            }
        }
        else
        {
            progressCircle.fillAmount = 0f; // 重置进度圈填充量
        }
    }


    private bool IsFingerOnButtonLine(Vector3 fingerScreenPosition, Button button)
    {
        // 获取按钮的屏幕矩形区域
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        Rect buttonRect = rectTransform.rect;

        // 将摄像头屏幕位置作为参考点
        Vector3 cameraScreenPosition = mainCamera.WorldToScreenPoint(Vector3.zero);

        // 计算手指与摄像头屏幕位置之间的方向向量
        Vector3 direction = (fingerScreenPosition - cameraScreenPosition).normalized;

        // 沿方向向量发射一条射线
        Ray ray = new Ray(cameraScreenPosition, direction);
        RaycastHit hit;

        // 检测射线是否与按钮矩形相交。如果相交，则说明手指、摄像头屏幕区域和按钮连成一条线。
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