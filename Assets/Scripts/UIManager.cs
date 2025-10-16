using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] public MathQuestionUIManager mathQuestionUIManager;
    [SerializeField] public TimeUI timeText;
    [SerializeField] public GameObject GameOverPanel;

    private IEnumerator Start()
    {
        if (mathQuestionUIManager == null)
        {
            mathQuestionUIManager = FindAnyObjectByType<MathQuestionUIManager>();
        }

        if (timeText == null)
        {
            timeText = FindAnyObjectByType<TimeUI>();
        }
        yield return null;
    }
}
