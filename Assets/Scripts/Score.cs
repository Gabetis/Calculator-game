using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentScore = 0;

    private void Awake()
    {
        if (scoreText == null)
        {
            scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        }
    }
    public void IncreaseScore()
    {
        currentScore++;
        UpdateScore(currentScore);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        currentScore = 0;
        scoreText.text = "0";
    }

    public void SaveBestScore()
    {
        int currentScore = int.Parse(scoreText.text);
        Debug.Log("Current Score: " + currentScore);
        GameEvent.TriggerSaveBestScore(currentScore);
    }
}
