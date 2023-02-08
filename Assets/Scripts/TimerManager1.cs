using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static void StartTimer()
    {
        EventManager.TriggerEvent("startTimer", null);
    }

    public static void StopTimer()
    {
        EventManager.TriggerEvent("stopTimer", null);
    }

    public static void ResetTimer()
    {
        EventManager.TriggerEvent("resetTimer", null);
    }
}
