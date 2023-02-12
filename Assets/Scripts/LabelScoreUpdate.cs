using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelScoreUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("updateScoreLabel", ScoreLabelUpdate);
    }

    void ScoreLabelUpdate(EventParam e)
    {
        if(e != null)
        {
            EventParamInt ei = (EventParamInt)e;
            GetComponent<Text>().text = "Score : " + ei.Value.ToString();
        }
    }
}
