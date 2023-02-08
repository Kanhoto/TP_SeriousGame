using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invalid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text text;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "pneu")
        {
            if (!collision.gameObject.GetComponent<WheelProp>().getCorrect())
            {
                ++Score.count;
                text.text = "Score : " + Score.count.ToString();
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "pneu")
        {
            if (!collision.gameObject.GetComponent<WheelProp>().getCorrect())
            {
                --Score.count;
                text.text = "Score : " + Score.count.ToString();
            }
        }
    }
}
