using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Applied to Tapis

public class Detectwheel : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I entered");
        // Recovering propreties
        WheelProp myScript = collision.gameObject.GetComponent<WheelProp>();
        bool is_conform = myScript.getCorrect();
        bool is_detected = myScript.getDetectable();

        if (is_conform && is_detected)
        {
            // Calling the conform event
            EventManager.TriggerEvent("conformWheel", new EventParam());
        }
        else if (!is_conform)
        {
            // Calling the bad event
            EventManager.TriggerEvent("badWheel", new EventParam());
        }

        else if (!is_detected)
        {
            // Calling the not scanned event
            EventManager.TriggerEvent("notscannedWheel", new EventParam());
        }

    }

    void OnCollisionExit(Collision collisionInfo)
    {
        // Calling the waiting event
        EventManager.TriggerEvent("missingWheel", new EventParam());
    }
}