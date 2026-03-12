using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance { get; private set; }
    public GameModeType CurrentGameMode { get; set; } = GameModeType.None;
    public int MinNumber { get; set; }
    public int MaxNumber { get; set; }
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
        Minus,
        Mul,
        Div
    }

    public void SetGameMode(GameModeType mode)
    {
        CurrentGameMode = mode;
    }

    public void SetDifficulty(int min, int max)
    {
        MinNumber = min;
        MaxNumber = max;
    }

    public void CurrentMode()
    {
        Debug.Log("Current Game Mode: " + CurrentGameMode.ToString());
    }
}
