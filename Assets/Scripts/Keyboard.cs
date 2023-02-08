using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*********************
 * Ne fonctionne pas *
 *********************/

public class Keyboard : MonoBehaviour
{
    public GameObject keyPrefab; // Prefab for the keys

    private Dictionary<char, GameObject> keys = new Dictionary<char, GameObject>(); // Dictionary to store the keys

    private string[] keyboardRows = { "qwertyuiop", "asdfghjkl", "zxcvbnm" }; // Array of strings representing the keyboard rows

    private float keySpacing = 0.1f; // Spacing between the keys

    void Start()
    {
        // Calculate the starting position for the keyboard
        Vector3 startPos = transform.position - (new Vector3(keyboardRows[0].Length / 2 * keySpacing, 0, 0));

        // Loop through each row of the keyboard
        for (int i = 0; i < keyboardRows.Length; i++)
        {
            // Calculate the position for the first key in this row
            Vector3 pos = startPos + (new Vector3(0, 0, i * keySpacing));
            Debug.Log("1 create key");

            // Loop through each key in the row
            for (int j = 0; j < keyboardRows[i].Length; j++)
            {
                Debug.Log("2 create key");
                // Instantiate a key at the current position
                GameObject key = Instantiate(keyPrefab, pos, Quaternion.identity, transform);

                Debug.Log("3 create key");
                // Set the key's label
                key.GetComponent<setTextKey>().setKeyText(keyboardRows[i][j].ToString());

                Debug.Log("4 create key");
                // Add the key to the dictionary
                keys.Add(keyboardRows[i][j], key);

                // Move the position for the next key
                pos += new Vector3(keySpacing, 0, 0);
                Debug.Log("5 create key");
            }
        }
    }

    public void PressKey(char key)
    {
        // Check if the key exists in the dictionary
        if (keys.ContainsKey(key))
        {
            // Play the press animation for the key
            //keys[key].GetComponent<Animator>().Play("Press");
        }
    }
}