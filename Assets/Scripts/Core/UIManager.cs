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
    public GameObject MenuPanel;
    public GameObject SettingsPanel;
    public GameObject GameModePanel;
    public GameObject AddPanel;
    public GameObject MinusPanel;
    public GameObject MulPanel;
    public GameObject DivPanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
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

        if (SceneLoader.Instance.CurrentScence() == "MenuScene")
        {
            if (MenuPanel == null)
            {
                MenuPanel = transform.Find("Menu").gameObject;
            }
        }

        if(AddPanel == null)
        {
            AddPanel = MenuPanel.transform.Find("AddPanel").gameObject;
        }

        if(MinusPanel == null)
        {
            MinusPanel = MenuPanel.transform.Find("MinusPanel").gameObject;
        }

        if(DivPanel == null)
        {
            DivPanel = MenuPanel.transform.Find("MulPanel").gameObject;
        }

        if(MulPanel == null)
        {
            MulPanel = MenuPanel.transform.Find("DivPanel").gameObject;
        }

        yield return null;
    }

    private void OnSaveBestStreak(int streak)
    {
        if (bestUI != null)
            bestUI.SaveBestStreak(streak);
    }
}
