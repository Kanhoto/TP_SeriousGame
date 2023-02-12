using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelChronoUpdater : MonoBehaviour
{
    // Start is called before the first frame update 
    void Start()
    {
        EventManager.StartListening("chronometerTime", setTimerLabel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setTimerLabel(EventParam e)
    {
        if (e != null)
        {
            EventParamFloat ef = (EventParamFloat)e;
            GetComponent<Text>().text = "Time : " + ef.Value.ToString();
        }
    }
}
