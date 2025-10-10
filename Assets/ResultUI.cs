using UnityEngine;
using System.Collections;
public class ResultUI : MonoBehaviour
{
    [SerializeField] private GameObject Correct;
    [SerializeField] private GameObject Wrong;

    private IEnumerator Start()
    {
        if (Correct == null)
        {
            Correct = transform.Find("Correct").gameObject;
        }
        if (Wrong == null)
        {
            Wrong = transform.Find("Wrong").gameObject;
        }
        yield return null;
    }

    public void ShowCorrect()
    {
        Correct.SetActive(true);
        Wrong.SetActive(false);
    }

    public void ShowWrong()
    {
        Correct.SetActive(false);
        Wrong.SetActive(true);
    }

    public void Reset()
    {
        Correct.SetActive(false);
        Wrong.SetActive(false);
    }
}
