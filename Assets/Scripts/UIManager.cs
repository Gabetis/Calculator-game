using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] public MathQuestionUIManager mathQuestionUIManager;
    [SerializeField] public TimeUI timeText;
    [SerializeField] public GameObject GameOverPanel;
    [SerializeField] public StreakText streakText;
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

        if(streakText == null)
        {
            streakText = GetComponentInChildren<StreakText>();
        }
        yield return null;
    }
}
