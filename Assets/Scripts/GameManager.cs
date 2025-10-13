using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager UImanager;
    private int number1;
    private int number2;
    private int userResult = 0;
    private IEnumerator Start()
    {
        if (UImanager == null)
        {
            UImanager = FindAnyObjectByType<UIManager>();
        }
        yield return null;

        RandomNumber();
        UImanager.mathQuestionUIManager.Result.onEndEdit.AddListener(CheckAnswer);
        UImanager.timeText.StartCountDown();
    }

    private void CheckAnswer(string text)
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

        if (number1 + number2 == userResult)
        {
            Debug.Log("Correct");
            UImanager.resultUI.ShowCorrect();
            UImanager.timeText.TimeStop();
            Invoke("RandomNumber", 2f);
            Invoke("ResetResultUI", 2f);
        }
        else
        {
            Debug.Log("Wrong");
            UImanager.resultUI.ShowWrong();
        }
    }
    private void RandomNumber()
    {
        number1 = Random.Range(0, 10);
        number2 = Random.Range(0, 10);
        UImanager.mathQuestionUIManager.Number1.text = number1.ToString();
        UImanager.mathQuestionUIManager.Number2.text = number2.ToString();
        UImanager.mathQuestionUIManager.Operator.text = "+";
    }

    private void ResetResultUI()
    {
        UImanager.resultUI.Reset();
        UImanager.mathQuestionUIManager.Result.text = string.Empty;
        UImanager.timeText.TimeReset();
        UImanager.timeText.StartCountDown();    
    }
}


