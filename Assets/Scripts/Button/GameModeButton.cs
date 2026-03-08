using UnityEngine;
using UnityEngine.UI;

public class GameModeButton : MonoBehaviour
{
    private enum GameModeType
    {
        Add,
        Minus,
        Mul,
        Div
    }

    [SerializeField] private Button gameModeButton;
    [SerializeField] private GameModeType gameModeType;

    private void Start()
    {
        if(gameModeButton == null)
        {
            gameModeButton = GetComponent<Button>();
        }
        gameModeButton.onClick.AddListener(OnGameModeButtonClicked);
    }

    public void OnGameModeButtonClicked()
    {
        AudioManager.Instance.PlayButtonClickSound();
        switch (gameModeType)
        {
            case GameModeType.Add:
                GameModeManager.Instance.SetGameMode(GameModeManager.GameModeType.Add);
                UIManager.Instance.GameModePanel.SetActive(false);
                UIManager.Instance.AddPanel.SetActive(true);
                break;
            case GameModeType.Minus:
                GameModeManager.Instance.SetGameMode(GameModeManager.GameModeType.Minus);
                UIManager.Instance.GameModePanel.SetActive(false);
                UIManager.Instance.MinusPanel.SetActive(true);
                break;
            case GameModeType.Mul:
                GameModeManager.Instance.SetGameMode(GameModeManager.GameModeType.Mul);
                UIManager.Instance.GameModePanel.SetActive(false);
                UIManager.Instance.MulPanel.SetActive(true);
                break;
            case GameModeType.Div:
                GameModeManager.Instance.SetGameMode(GameModeManager.GameModeType.Div);
                UIManager.Instance.GameModePanel.SetActive(false);
                UIManager.Instance.DivPanel.SetActive(true);
                break;
        }
    }
}
