using UnityEngine;
using UnityEngine.UI;
public class SettingButton : MonoBehaviour
{
    [SerializeField] private Button playButton;
    private void Awake()
    {
        if (playButton == null)
        {
            playButton = GetComponent<Button>();
        }
        playButton.onClick.AddListener(OnSettingButtonClicked);
    }

    public void OnSettingButtonClicked()
    {
        AudioManager.Instance.PlayButtonClickSound();
        if (SceneLoader.Instance.CurrentScence() == "MenuScene")
        {
            UIManager.Instance.MenuPanel.SetActive(false);
            UIManager.Instance.SettingsPanel.SetActive(true);
        }
        else
        {
            UIManager.Instance.SettingsPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
