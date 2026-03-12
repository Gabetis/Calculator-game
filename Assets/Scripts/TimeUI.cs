using UnityEngine;
using TMPro;
using System.Collections;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private UIManager uiManager;
    private int time;
    Coroutine startCountDown;
    private void Start()
    {
        if (timeText == null)
        {
            timeText = GetComponent<TextMeshProUGUI>();
        }

        if(uiManager == null)
        {
            uiManager = FindAnyObjectByType<UIManager>();
        }
    }

    public void StartCountDown()
    {
        time = int.Parse(timeText.text);
        startCountDown = StartCoroutine(CountDownTime());
    }
    public IEnumerator CountDownTime()
    {
        while (time > 0)
        {
            time--;
            timeText.text = time.ToString();
            AudioManager.Instance.TickTingSound();

            yield return new WaitForSeconds(1f);
        }

        GameEvent.TriggerTimeOut();
    }

    public void TimeReset()
    {
        time = 21;
        timeText.text = time.ToString();
    }

    public void TimeStop()
    {
        if (startCountDown != null)
        {
            StopCoroutine(startCountDown);
        }
    }
}
