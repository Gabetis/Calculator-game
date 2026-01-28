using UnityEngine;
using UnityEngine.UI;
public class BackButton : MonoBehaviour
{
    private enum BackType
    {
        SettingToMenu,
        GameModeToMenu
    }

    [SerializeField] private Button backButton;
    [SerializeField] private BackType backType;
    private void Awake()
    {
        if (backButton == null)
        {
            backButton = GetComponent<Button>();
        }
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    public void OnBackButtonClicked()
    {
        AudioManager.Instance.PlayButtonClickSound();
        switch(backType)
        {
            case BackType.SettingToMenu:
                onSettingToMenu();
                break;
            case BackType.GameModeToMenu:
                onGameModeToMenu();
                break;
        }
    }

    private void onSettingToMenu()
    {
        UIManager.Instance.SettingsPanel.SetActive(false);
        UIManager.Instance.MenuPanel.SetActive(true);
    }

    private void onGameModeToMenu()
    {
        UIManager.Instance.GameModePanel.SetActive(false);
        UIManager.Instance.MenuPanel.SetActive(true);
    }
}
