using UnityEngine;
using UnityEngine.UI;
public class TimeToggle : MonoBehaviour
{
    [SerializeField] private Toggle timeToggleButton;

    private void Awake()
    {
        if (timeToggleButton == null)
        {
            timeToggleButton = GetComponent<Toggle>();
        }
    }

    private void Start()
    {
        bool isOn = PlayerPrefs.GetInt("TimeToggle", 0) == 1;

        timeToggleButton.isOn = isOn;

        timeToggleButton.onValueChanged.AddListener(OnToggleValueChanged);
    }

    public void OnToggleValueChanged(bool isOn)
    {
        PlayerPrefs.SetInt("TimeToggle", isOn ? 1 : 0);
    }
}
