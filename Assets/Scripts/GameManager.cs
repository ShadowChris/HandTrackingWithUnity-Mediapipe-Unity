using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button startButton; // 开始按钮
    public TextMeshProUGUI timerText; // 倒计时显示
    public TextMeshProUGUI scoreText; // 分数显示
    public int gameDuration = 60; // 游戏时长，你可以在Unity编辑器中设置
    private int score = 0; // 分数
    private float timeLeft; // 剩余时间

    public GameObject target;
    public GameObject TestCube2;
    public ScoreCounter targetScoreCounter;

    void Start()
    {
        //// 获取target的计分器
        //targetScoreCounter = target.GetComponent<ScoreCounter>();
        // 初始化游戏
        InitGame();

    }

    void Update()
    {

        // 如果游戏正在进行，更新计时器
        if (startButton.gameObject.activeSelf == false)
        {
            score = targetScoreCounter.getScore();
            scoreText.text = "Score\n" + score;

            timeLeft -= Time.deltaTime;
            timerText.text = "Time left\n " + Mathf.Max(0, (int)timeLeft);

            if (timeLeft <= 0)
            {
                // 游戏结束
                EndGame();
            }
        }
    }

    // 开始游戏
    public void StartGame()
    {
        startButton.gameObject.SetActive(false); // 隐藏开始按钮
        targetScoreCounter.resetScore(); // 分数清零
        timeLeft = gameDuration; // 设置倒计时
    }

    // 结束游戏
    private void EndGame()
    {
        startButton.gameObject.SetActive(true); // 显示开始按钮
        scoreText.text = "Final score\n" + score; // 显示最终分数
        target.SetActive(false);
        TestCube2.SetActive(false);

    }

    // 初始化游戏
    private void InitGame()
    {
        startButton.gameObject.SetActive(true); // 显示开始按钮
        startButton.onClick.AddListener(StartGame); // 绑定开始按钮点击事件
        //scoreText.text = "Score\n" + score; // 显示分数
    }

    //// 加分
    //public void IncreaseScore(int value)
    //{
    //    if (startButton.gameObject.activeSelf == false)
    //    {
    //        score += value;
    //        scoreText.text = "Score: " + score; // 更新分数显示
    //    }
    //}
}
