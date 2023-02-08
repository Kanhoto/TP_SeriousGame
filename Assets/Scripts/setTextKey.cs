using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class setTextKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject keyText;

    public void setKeyText(string text)
    {
        keyText.GetComponent<TextMeshPro>().text = text;
    }
}
