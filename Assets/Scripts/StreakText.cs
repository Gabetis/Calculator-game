using UnityEngine;
using TMPro;
public class StreakText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreStreakText;

    private void Start()
    {
        if (scoreStreakText == null)
        {
            scoreStreakText = transform.Find("StreakScore").GetComponentInChildren<TextMeshProUGUI>();
        }    
    }

    public void IncreaseStreak()
    {
        scoreStreakText.text = (int.Parse(scoreStreakText.text) + 1).ToString();
    }    

    public void ResetStreak()
    {
        scoreStreakText.text = "0";
    }

    public void SaveBestStreak()
    {
        int currentStreak = int.Parse(scoreStreakText.text);
        Debug.Log("Current Streak: " + currentStreak); 
        GameEvent.TriggerSaveBestStreak(currentStreak);
    }
}
