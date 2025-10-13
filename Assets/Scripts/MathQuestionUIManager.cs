using UnityEngine;
using TMPro;
public class MathQuestionUIManager : MonoBehaviour
{
    public TextMeshProUGUI Number1;
    public TextMeshProUGUI Number2;
    public TextMeshProUGUI Operator;
    public TMP_InputField Result;

    public void Start()
    {
        if (Number1 == null)
        {
            Number1 = transform.Find("Number (1)").GetComponentInChildren<TextMeshProUGUI>();
        }

        if (Number2 == null)
        {
            Number2 = transform.Find("Number (2)").GetComponentInChildren<TextMeshProUGUI>();
        }

        if (Operator == null)
        {
            Operator = transform.Find("Operator").GetComponentInChildren<TextMeshProUGUI>();
        }

        if (Result == null)
        {
            Result = transform.Find("Result").GetComponentInChildren<TMP_InputField>();
        }
    }
}
