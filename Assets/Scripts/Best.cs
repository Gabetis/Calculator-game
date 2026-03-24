using UnityEngine;
using TMPro;
public class Best : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI bestStreakText;

    private void Awake()
    {
        Debug.Log("BEST AWAKE");
        GameEvent.OnSaveBestStreak += SaveBestStreak;
        GameEvent.OnSaveBestScore += SaveBestScore;

        LoadBestStreak();
        LoadBestScore();
    }
    public void SaveBestStreak(int currentStreak)
    {
        if(currentStreak > PlayerPrefs.GetInt("BestStreak", 0))
        {
            PlayerPrefs.SetInt("BestStreak", currentStreak);
            PlayerPrefs.Save();
            LoadBestStreak();
            Debug.Log("BEST RECEIVED STREAK: " + currentStreak);
        }
    }

    public void LoadBestStreak()
    {
        bestStreakText.text = PlayerPrefs.GetInt("BestStreak", 0).ToString();
    }

    public void SaveBestScore(int currentScore)
    {
        if(currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            PlayerPrefs.Save();
            LoadBestScore();
            Debug.Log("BEST RECEIVED SCORE: " + currentScore);
        }
    }

    public void LoadBestScore()
    {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    private void OnDisable()
    {
        GameEvent.OnSaveBestStreak -= SaveBestStreak;
        GameEvent.OnSaveBestScore -= SaveBestScore;
    }
}
