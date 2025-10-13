using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] public MathQuestionUIManager mathQuestionUIManager;
    [SerializeField] public ResultUI resultUI;
    [SerializeField] public TimeUI timeText;
    [SerializeField] public GameObject GameOverPanel;

    private IEnumerator Start()
    {
        if (mathQuestionUIManager == null)
        {
            mathQuestionUIManager = FindAnyObjectByType<MathQuestionUIManager>();
        }

        if (resultUI == null)
        {
            resultUI = FindAnyObjectByType<ResultUI>();
        }

        if (timeText == null)
        {
            timeText = FindAnyObjectByType<TimeUI>();
        }
        yield return null;
    }
}
