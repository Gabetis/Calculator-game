using UnityEngine;
using System;
using UnityEngine.Events;
public static class GameEvent
{
    public static event Action OnTimeOut;
    public static void TriggerTimeOut() => OnTimeOut?.Invoke();

    public static event Action OnIncreaseScore;
    public static void TriggerIncreaseScore() => OnIncreaseScore?.Invoke();

    public static event Action<int> OnSaveBestStreak;   
    public static void TriggerSaveBestStreak(int StreakScore) => OnSaveBestStreak?.Invoke(StreakScore);
    public static event Action<int> OnSaveBestScore;
    public static void TriggerSaveBestScore(int Score) => OnSaveBestScore?.Invoke(Score);

    public static event Action OnChangeScene;
    public static void TriggerChangeScene() => OnChangeScene?.Invoke();
}
