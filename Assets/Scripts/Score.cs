using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (scoreText == null)
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
        GameEvent.OnIncreaseScore += IncreaseScore;
    }

    public void IncreaseScore()
    {
        int score = int.Parse(scoreText.text);
        score++;
        UpdateScore(score);
    }    

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }    

    public void ResetScore()
    {
        scoreText.text = "0";
    }
}
