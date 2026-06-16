using UnityEngine;

public class CreateQuestion : MonoBehaviour
{
    public int Number1 { get; private set; }
    public int Number2 { get; private set; }
    public GameModeManager.GameModeType Mode { get; private set; }

    public CreateQuestion(int min, int max, GameModeManager.GameModeType mode)
    {
        Mode = mode;

        if (mode == GameModeManager.GameModeType.Minus)
        {
            Number1 = Random.Range(min, max);
            Number2 = Random.Range(min, Number1); // Ensure Number2 is less than or equal to Number1
            return;
        }
        else if (mode == GameModeManager.GameModeType.Mul || mode == GameModeManager.GameModeType.Add)
        {
            Number1 = Random.Range(min, max);
            Number2 = Random.Range(min, max);
        }
        else if (mode == GameModeManager.GameModeType.Div)
        {
            Number2 = Random.Range(1, max); // Avoid zero for division
            Number1 = Number2 * Random.Range(min, max / Number2); // Ensure a clean division
        }
    }

    public static int Create(int a, int b, GameModeManager.GameModeType mode)
    {
        switch (mode)
        {
            case GameModeManager.GameModeType.Add:
                return a + b;
            case GameModeManager.GameModeType.Minus:
                return a - b;
            case GameModeManager.GameModeType.Mul:
                return a * b;
            case GameModeManager.GameModeType.Div:
                if (b == 0) return 0; // Avoid division by zero
                return a / b;

            default:
                return 0;
        }
    }

    public int GetAnswer()
    {
        return Create(Number1, Number2, Mode);
    }

}
