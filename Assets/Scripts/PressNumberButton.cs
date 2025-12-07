using UnityEngine;
using UnityEngine.UI;

public class PressNumberButto : MonoBehaviour
{
    [SerializeField] private GameObject numberGameobject;
    [SerializeField] private Button btn;
    [SerializeField] private MathQuestionUIManager mathQuestionUIManager;

    private void Start()
    {
        if (numberGameobject == null)
        {
            numberGameobject = this.gameObject;
            btn = numberGameobject.GetComponent<Button>();
        }

        if (mathQuestionUIManager == null)
        {
            mathQuestionUIManager = FindAnyObjectByType<MathQuestionUIManager>();
        }

        btn.onClick.AddListener(PressButton);
    }

    public void PressButton()
    {
        switch (numberGameobject.name)
        {
            case "1":
                Debug.Log("Pressed 1");
                mathQuestionUIManager.Result.text += "1";
                break;
            case "2":
                Debug.Log("Pressed 2");
                mathQuestionUIManager.Result.text += "2";
                break;
            case "3":
                Debug.Log("Pressed 3");
                mathQuestionUIManager.Result.text += "3";
                break;
            case "4":
                Debug.Log("Pressed 4");
                mathQuestionUIManager.Result.text += "4";
                break;
            case "5":
                Debug.Log("Pressed 5");
                mathQuestionUIManager.Result.text += "5";
                break;
            case "6":
                Debug.Log("Pressed 6");
                mathQuestionUIManager.Result.text += "6";
                break;
            case "7":
                Debug.Log("Pressed 7");
                mathQuestionUIManager.Result.text += "7";
                break;
            case "8":
                Debug.Log("Pressed 8");
                mathQuestionUIManager.Result.text += "8";
                break;
            case "9":
                Debug.Log("Pressed 9");
                mathQuestionUIManager.Result.text += "9";
                break;
            case "0":
                Debug.Log("Pressed 0");
                mathQuestionUIManager.Result.text += "0";
                break;
        }
    }
}
