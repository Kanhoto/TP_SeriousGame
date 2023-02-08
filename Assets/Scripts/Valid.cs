using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Valid : MonoBehaviour
{
    [SerializeField]
    private Text text;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "pneu")
        {
            if (collision.gameObject.GetComponent<WheelProp>().getCorrect())
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
            if (collision.gameObject.GetComponent<WheelProp>().getCorrect())
            {
                --Score.count;
                text.text = "Score : " + Score.count.ToString();
            }
        }
    }
}
