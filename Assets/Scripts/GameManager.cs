using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MathQuestionUIManager Question;
    [SerializeField] private UIManager UImanager;
    private int number1;
    private int number2;
    private int result;
    private IEnumerator Start()
    {
        if (Question == null)
        {
            Question = FindAnyObjectByType<MathQuestionUIManager>();
        }

        if (UImanager == null)
        {
            UImanager = FindAnyObjectByType<UIManager>();
        }
        yield return null;

        RandomNumber();
        Question.Result.onEndEdit.AddListener(CheckAnswer);
    }

    private void CheckAnswer(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            Debug.LogWarning("NULL");
            return;
        }

        int userResult;
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
        Question.Number1.text = number1.ToString();
        Question.Number2.text = number2.ToString();
        Question.Operator.text = "+";
    }
}


