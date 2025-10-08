using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] public MathQuestionUIManager mathQuestionUIManager;
    [SerializeField] public ResultUI resultUI;

    private IEnumerator Start()
    {
        if(mathQuestionUIManager == null)
        {
            mathQuestionUIManager = FindAnyObjectByType<MathQuestionUIManager>();
        }

        if(resultUI == null)
        {
            resultUI = FindAnyObjectByType<ResultUI>();
        }
        yield return null;
    }
}
