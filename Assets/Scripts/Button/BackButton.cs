using UnityEngine;
using UnityEngine.UI;
public class BackButton : MonoBehaviour
{
    private enum BackType
    {
        SettingToMenu,
        GameModeToMenu,
        SelectmodeToGameMode
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
        switch (backType)
        {
            case BackType.SettingToMenu:
                onSettingToMenu();
                break;
            case BackType.GameModeToMenu:
                onGameModeToMenu();
                break;
            case BackType.SelectmodeToGameMode:
                onSelectmodeToMenu();
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
    private void onSelectmodeToMenu()
    {
        if (GameModeManager.Instance.CurrentGameMode == GameModeManager.GameModeType.Add)
        {
            UIManager.Instance.AddPanel.SetActive(false);
            UIManager.Instance.GameModePanel.SetActive(true);
        }
        else if (GameModeManager.Instance.CurrentGameMode == GameModeManager.GameModeType.Minus)
        {
            UIManager.Instance.MinusPanel.SetActive(false);
            UIManager.Instance.GameModePanel.SetActive(true);
        }
        else if (GameModeManager.Instance.CurrentGameMode == GameModeManager.GameModeType.Mul)
        {
            UIManager.Instance.MulPanel.SetActive(false);
            UIManager.Instance.GameModePanel.SetActive(true);
        }
        else if (GameModeManager.Instance.CurrentGameMode == GameModeManager.GameModeType.Div)
        {
            UIManager.Instance.DivPanel.SetActive(false);
            UIManager.Instance.GameModePanel.SetActive(true);
        }
    }

}
