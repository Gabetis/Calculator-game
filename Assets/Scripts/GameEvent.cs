using UnityEngine;
using System;
using UnityEngine.Events;
public static class GameEvent
{
    public static event Action OnTimeOut;
    public static void TriggerTimeOut() => OnTimeOut?.Invoke();

    public static event Action OnIncreaseScore;
    public static void TriggerIncreaseScore() => OnIncreaseScore?.Invoke();
}
