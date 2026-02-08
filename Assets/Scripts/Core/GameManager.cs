using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private UIManager UImanager;
    private int number1;
    private int number2;
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

    private void OnDestroy()
    {
        GameEvent.OnTimeOut -= GameOver;
    }

    private void StartGame()
    {
        CreateQuestion();
        UImanager.timeText.StartCountDown();
    }

    private void CheckAnswer(string text)
    {
        int result = number1 + number2;
        if (isGameOver == false)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Debug.LogWarning("NULL");
                return;
            }

            bool success = int.TryParse(text, out userResult);

            if (!success)
            {
                Debug.LogWarning("INCORRECT FORMAT");
                return;
            }

            if (result == userResult)
            {
                UImanager.timeText.TimeStop();
                UImanager.streakText.IncreaseStreak();
                AudioManager.Instance.PlayCorrectSound();
                GameEvent.TriggerIncreaseScore();
                CreateQuestion();
                ResetQuestion();
            }
            else
            {
                AudioManager.Instance.PlayWrongSound();
                UImanager.streakText.SaveBestStreak();
                UImanager.streakText.ResetStreak();
            }
        }
        else return;
    } //bug
    private void CreateQuestion()
    {
        number1 = Random.Range(0, 10);
        number2 = Random.Range(0, 10);

        UImanager.mathQuestionUIManager.Number1.text = number1.ToString();
        UImanager.mathQuestionUIManager.Number2.text = number2.ToString();

        CreateOperator();
    }

    private void ResetQuestion()
    {
        var input = UImanager.mathQuestionUIManager.Result;

        UImanager.mathQuestionUIManager.Result.text = string.Empty;
        EventSystem.current.SetSelectedGameObject(input.gameObject);
        input.ActivateInputField();

        UImanager.timeText.TimeReset();
        UImanager.timeText.StartCountDown();
    }

    private void GameOver()
    {
        isGameOver = true;
        UImanager.streakText.SaveBestStreak();
        UImanager.GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        UImanager.score.ResetScore();
    }

    private void CreateOperator()
    {
        if (GameModeManager.Instance.CurrentGameMode == GameModeManager.GameModeType.Add)
            UImanager.mathQuestionUIManager.Operator.text = "+";
        else if (GameModeManager.Instance.CurrentGameMode == GameModeManager.GameModeType.Sub)
            UImanager.mathQuestionUIManager.Operator.text = "-";
        else if (GameModeManager.Instance.CurrentGameMode == GameModeManager.GameModeType.Mul)
            UImanager.mathQuestionUIManager.Operator.text = "×";
        else if (GameModeManager.Instance.CurrentGameMode == GameModeManager.GameModeType.Div)
            UImanager.mathQuestionUIManager.Operator.text = "÷";
        else if (GameModeManager.Instance.CurrentGameMode == GameModeManager.GameModeType.Random)
        {
            int randomOperator = Random.Range(0, 4);
            switch (randomOperator)
            {
                case 0:
                    UImanager.mathQuestionUIManager.Operator.text = "+";
                    break;
                case 1:
                    UImanager.mathQuestionUIManager.Operator.text = "-";
                    break;
                case 2:
                    UImanager.mathQuestionUIManager.Operator.text = "×";
                    break;
                case 3:
                    UImanager.mathQuestionUIManager.Operator.text = "÷";
                    break;
            }
        }
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
        isGameOver = false;
        AudioManager.Instance.PlayButtonClickSound();
        SceneLoader.Instance.LoadScene("MenuScene");
        Time.timeScale = 1f;
    }
}