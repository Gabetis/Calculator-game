using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public MathQuestionUIManager mathQuestionUIManager;
    public TimeUI timeText;
    public GameObject GameOverPanel;
    public StreakText streakText;
    public Best bestUI;
    public Score score;

    private IEnumerator Start()
    {
        if (mathQuestionUIManager == null)
        {
            mathQuestionUIManager = GetComponentInChildren<MathQuestionUIManager>();
        }

        if (timeText == null)
        {
            timeText = GetComponentInChildren<TimeUI>();
        }

        if (streakText == null)
        {
            streakText = GetComponentInChildren<StreakText>();
        }

        if (bestUI == null)
        {
            bestUI = GetComponentInChildren<Best>(true);
            GameEvent.OnSaveBestStreak += OnSaveBestStreak;
        }

        if (score == null)
        {
            score = GetComponentInChildren<Score>();
        }
        yield return null;
    }

    private void OnSaveBestStreak(int streak)
    {
        if (bestUI != null)
            bestUI.SaveBestStreak(streak);
    }
}
