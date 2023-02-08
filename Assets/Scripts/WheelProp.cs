using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelProp : MonoBehaviour
{
    // Start is called before the first frame update
    private bool correct,detectable;

    void Start()
    {
        correct = System.Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
        detectable = System.Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getCorrect()
    {
        return correct;
    }

    public bool getDetectable()
    {
        return detectable;
    }
}
