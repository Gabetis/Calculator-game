using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance { get; private set; }
    public GameModeType CurrentGameMode { get; set; } = GameModeType.None;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public enum GameModeType
    {
        None,
        Add,
        Sub,
        Mul,
        Div
    }

    public void SetGameMode(GameModeType mode)
    {
        CurrentGameMode = mode;
    }
}
