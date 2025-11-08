using UnityEngine;
using TMPro;
public class Best : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI bestStreakText;

    private void Awake()
    {
        LoadBestStreak();
    }
    public void SaveBestStreak(int currentStreak)
    {
        if(currentStreak > PlayerPrefs.GetInt("BestStreak", 0))
        {
            PlayerPrefs.SetInt("BestStreak", currentStreak);
        }
    }

    public void LoadBestStreak()
    {
        bestStreakText.text = PlayerPrefs.GetInt("BestStreak", 0).ToString();
    }

}
