using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MathQuestionUIManager Question;
    private int number1;
    private int number2;
    private int result;
    private IEnumerator Start()
    {
        if (Question == null)
        {
            Question = FindAnyObjectByType<MathQuestionUIManager>();
        }

        yield return null;

        RandomNumber();
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


