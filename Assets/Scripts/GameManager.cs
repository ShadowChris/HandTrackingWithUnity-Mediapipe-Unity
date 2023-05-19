using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button startButton; // ��ʼ��ť
    public TextMeshProUGUI timerText; // ����ʱ��ʾ
    public TextMeshProUGUI scoreText; // ������ʾ
    public int gameDuration = 60; // ��Ϸʱ�����������Unity�༭��������
    private int score = 0; // ����
    private float timeLeft; // ʣ��ʱ��

    public GameObject target;
    public GameObject TestCube2;
    public ScoreCounter targetScoreCounter;

    void Start()
    {
        //// ��ȡtarget�ļƷ���
        //targetScoreCounter = target.GetComponent<ScoreCounter>();
        // ��ʼ����Ϸ
        InitGame();

    }

    void Update()
    {

        // �����Ϸ���ڽ��У����¼�ʱ��
        if (startButton.gameObject.activeSelf == false)
        {
            score = targetScoreCounter.getScore();
            scoreText.text = "Score\n" + score;

            timeLeft -= Time.deltaTime;
            timerText.text = "Time left\n " + Mathf.Max(0, (int)timeLeft);

            if (timeLeft <= 0)
            {
                // ��Ϸ����
                EndGame();
            }
        }
    }

    // ��ʼ��Ϸ
    public void StartGame()
    {
        startButton.gameObject.SetActive(false); // ���ؿ�ʼ��ť
        targetScoreCounter.resetScore(); // ��������
        timeLeft = gameDuration; // ���õ���ʱ
    }

    // ������Ϸ
    private void EndGame()
    {
        startButton.gameObject.SetActive(true); // ��ʾ��ʼ��ť
        scoreText.text = "Final score\n" + score; // ��ʾ���շ���
        target.SetActive(false);
        TestCube2.SetActive(false);

    }

    // ��ʼ����Ϸ
    private void InitGame()
    {
        startButton.gameObject.SetActive(true); // ��ʾ��ʼ��ť
        startButton.onClick.AddListener(StartGame); // �󶨿�ʼ��ť����¼�
        //scoreText.text = "Score\n" + score; // ��ʾ����
    }

    //// �ӷ�
    //public void IncreaseScore(int value)
    //{
    //    if (startButton.gameObject.activeSelf == false)
    //    {
    //        score += value;
    //        scoreText.text = "Score: " + score; // ���·�����ʾ
    //    }
    //}
}
