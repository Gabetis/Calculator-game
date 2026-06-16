using UnityEngine;
using UnityEngine.UI;
public class ContinueButton : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    private void Awake()
    {
        if(continueButton == null)
        {
            continueButton = GetComponent<Button>();
        }
        continueButton.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        AudioManager.Instance.PlayButtonClickSound();
        UIManager.Instance.SettingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
