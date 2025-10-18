using UnityEngine;
using TMPro;
public class StreakText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreStreakText;

    private void Start()
    {
        if (scoreStreakText == null)
        {
            scoreStreakText = transform.Find("Score").GetComponentInChildren<TextMeshProUGUI>();
        }    
    }

    public void IncreaseScore()
    {
        scoreStreakText.text = (int.Parse(scoreStreakText.text) + 1).ToString();
    }    

    public void ResetScore()
    {
        scoreStreakText.text = "0";
    }
}
