using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private UIManager UImanager;
    [SerializeField] private CreateQuestion currentQuestion;
    private int userResult = 0;
    private bool isGameOver = false;
    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
        if (UImanager == null)
        {
            UImanager = FindAnyObjectByType<UIManager>();
        }
        yield return null;

        GameEvent.OnTimeOut += GameOver;

        StartGame();

        //Call CheckAnswer when the input field editing ends (Enter or click outside)
        UImanager.mathQuestionUIManager.Result.onEndEdit.AddListener(CheckAnswer);// AddListener will call CheckAnswer function when onEndEdit is triggered (Enter or click outside)  
    }

    public void OnSubmitAnswer(string text)
    {
        CheckAnswer(text);
    }

    private void StartGame()
    {
        if (SceneLoader.Instance.CurrentScence() == "GameScene")
        {
            CreateQuestion();

            bool isTimeOn = PlayerPrefs.GetInt("TimeToggle", 0) == 1;

            if (isTimeOn)
            {
                UImanager.timeText.TimeReset();
                UImanager.timeText.StartCountDown();
            }
            else
            {
                UImanager.timeText.TimeStop();
                UImanager.timeText.ClearTime();
            }
        }
    }

    private void CheckAnswer(string text)
    {
        if (isGameOver) return;

        if (string.IsNullOrWhiteSpace(text))
            return;

        if (!int.TryParse(text, out int userResult))
            return;

        int correctAnswer = currentQuestion.GetAnswer();

        if (userResult == correctAnswer)
        {
            HandleCorrect();
        }
        else
        {
            HandleWrong();
        }
    }

    private void HandleCorrect()
    {
        UImanager.timeText.TimeStop();
        UImanager.streakText.IncreaseStreak();
        AudioManager.Instance.PlayCorrectSound();
        GameEvent.TriggerIncreaseScore();

        CreateQuestion();
        ResetQuestion();
    }

    private void HandleWrong()
    {
        AudioManager.Instance.PlayWrongSound();
        UImanager.streakText.SaveBestStreak();
        UImanager.streakText.ResetStreak();
    }

    private void CreateQuestion()
    {
        currentQuestion = new CreateQuestion(
            GameModeManager.Instance.MinNumber,
            GameModeManager.Instance.MaxNumber,
            GameModeManager.Instance.CurrentGameMode
        );

        UImanager.mathQuestionUIManager.Number1.text =
            currentQuestion.Number1.ToString();

        UImanager.mathQuestionUIManager.Number2.text =
            currentQuestion.Number2.ToString();

        CreateOperator(currentQuestion.Mode);
    }

    private void ResetQuestion()
    {
        var input = UImanager.mathQuestionUIManager.Result;

        UImanager.mathQuestionUIManager.Result.text = string.Empty;
        EventSystem.current.SetSelectedGameObject(input.gameObject);
        input.ActivateInputField();

        bool isTimeOn = PlayerPrefs.GetInt("TimeToggle", 0) == 1;

        if (isTimeOn)
        {
            UImanager.timeText.TimeReset();
            UImanager.timeText.StartCountDown();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        UImanager.streakText.SaveBestStreak();
        UImanager.GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        UImanager.score.ResetScore();
    }

    private void CreateOperator(GameModeManager.GameModeType currentMode)
    {
        if (currentMode == GameModeManager.GameModeType.Add)
            UImanager.mathQuestionUIManager.Operator.text = "+";
        else if (currentMode == GameModeManager.GameModeType.Minus)
            UImanager.mathQuestionUIManager.Operator.text = "-";
        else if (currentMode == GameModeManager.GameModeType.Mul)
            UImanager.mathQuestionUIManager.Operator.text = "×";
        else if (currentMode == GameModeManager.GameModeType.Div)
            UImanager.mathQuestionUIManager.Operator.text = "÷";
    }
    public void Retry()
    {
        isGameOver = false;
        AudioManager.Instance.PlayButtonClickSound();
        UImanager.GameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        ResetQuestion();
        UImanager.streakText.ResetStreak();
    }

    public void BackToMenu()
    {
        SceneLoader.Instance.LoadScene("MenuScene");
        isGameOver = false;
        AudioManager.Instance.PlayButtonClickSound();
        UImanager.GameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        GameEvent.OnTimeOut -= GameOver;
    }
}