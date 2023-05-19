using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour
{
    private int score = 0;

    public Text ScoreText;

    private void Start()
    {
        ScoreText.text = score.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            score++;
            ScoreText.text = score.ToString();
        }
    }
    
    public void resetScore()
    {
        score = 0;
    }

    public int getScore()
    {
        return score;
    }
}
