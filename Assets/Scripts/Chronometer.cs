using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    private bool timeractive = false;
    private EventParamFloat currentTime = new EventParamFloat
    {
        Value = 0
    };

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("startTimer", StartTimer);
        EventManager.StartListening("stopTimer", StopTimer);
        EventManager.StartListening("resetTimer", ResetTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeractive)
        {
            currentTime.Value += Time.deltaTime;
            EventManager.TriggerEvent("chronometerTime", currentTime);
        }
        //currentTimeText.text = "Time : " + currentTime.ToString();
    }

    public void StartTimer(EventParam e)
    {
        timeractive = true;
    }

    public void StopTimer(EventParam e)
    {
        timeractive = false;
    }

    public void ResetTimer(EventParam e)
    {
        timeractive = false;
        currentTime.Value = 0f;
        EventManager.TriggerEvent("chronometerTime", currentTime);
    }
}
