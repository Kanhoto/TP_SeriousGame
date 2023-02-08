using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Applied to Tapis

public class WheelResult : MonoBehaviour
{
    [SerializeField]
    private Material conformMaterial, errorMaterial, waitingMaterial, notscannedMaterial;

    [SerializeField]
    private GameObject ecran;

    // Start is called before the first frame update
    void Start()
    {
        // Listening to events
        EventManager.StartListening("badWheel", badDisplay);
        EventManager.StartListening("conformWheel", conformDisplay);
        EventManager.StartListening("missingWheel", missingDisplay);
        EventManager.StartListening("notscannedWheel", noscanDisplay);
    }

    private void badDisplay(EventParam obj)
    {
        ecran.GetComponent<Renderer>().material = errorMaterial;
    }

    private void conformDisplay(EventParam obj)
    {
        ecran.GetComponent<Renderer>().material = conformMaterial;
    }

    private void missingDisplay(EventParam obj)
    {
        ecran.GetComponent<Renderer>().material = waitingMaterial;
    }

    private void noscanDisplay(EventParam obj)
    {
        ecran.GetComponent<Renderer>().material = notscannedMaterial;
    }


}