using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Scan : MonoBehaviour
{
    public SteamVR_Action_Boolean scanray;
    public SteamVR_Input_Sources handType;
    public LineRenderer line;

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        line.enabled = false;
        if (scan())
        {
            line.enabled = true;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, transform.position + hit.distance * Vector3.forward);
                //Debug.DrawRay(transform.position /*+ new Vector3(0f , 0.004f, 0.002f)*/, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if (hit.transform.tag == "CB")
                {
                    Debug.Log("Did Hit");

                    WheelProp myScript = hit.transform.GetComponentInParent<WheelProp>();
                    bool is_conform = myScript.getCorrect();


                    if (is_conform)
                    {
                        // Calling the conform event
                        EventManager.TriggerEvent("conformWheel", new EventParam());
                    }
                    else if (!is_conform)
                    {
                        // Calling the bad event
                        EventManager.TriggerEvent("badWheel", new EventParam());
                    }
                }
                Debug.Log(hit.transform.name);
            }  
        }
    }
    private bool scan()
    {
        return scanray.GetStateDown(handType);
    }

}