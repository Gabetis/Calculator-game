using UnityEngine;
using UnityEngine.UI;

public class GameModeButton : MonoBehaviour
{
    private enum GameModeType
    {
        Add,
        Sub,
        Mul,
        Div,
        Random
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
                SceneLoader.Instance.LoadScene("GameScene");
                break;
            case GameModeType.Sub:
                GameModeManager.Instance.SetGameMode(GameModeManager.GameModeType.Sub);
                SceneLoader.Instance.LoadScene("GameScene");
                break;
            case GameModeType.Mul:
                GameModeManager.Instance.SetGameMode(GameModeManager.GameModeType.Mul);
                SceneLoader.Instance.LoadScene("GameScene");
                break;
            case GameModeType.Div:
                GameModeManager.Instance.SetGameMode(GameModeManager.GameModeType.Div);
                SceneLoader.Instance.LoadScene("GameScene");
                break;
            case GameModeType.Random:
                GameModeManager.Instance.SetGameMode(GameModeManager.GameModeType.Random);
                SceneLoader.Instance.LoadScene("GameScene");
                break;
        }
        //UIManager.Instance.MenuPanel.SetActive(false);
    }
}
