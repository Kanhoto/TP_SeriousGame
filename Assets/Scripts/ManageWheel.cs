using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageWheel : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnPneu, Pneu;

    private bool started = false;

    // Update is called once per frame
    void Update()
    {
        CompleteGoal();
    }

    public void SpawnWheel()
    {
        if (!started)
        {
            for (int i = 0; i < 10; ++i)
            {
                GameObject go = Instantiate(Pneu, SpawnPneu.transform);
                go.SetActive(true);
   
            }
            started = true;
            TimerManager.StartTimer();
        }
    }

    public void RemoveWheel()
    {
        if (started)
        {
            foreach (GameObject child in GameObject.FindGameObjectsWithTag("pneu"))
            {
                Destroy(child);
            }
            started = false;
            TimerManager.ResetTimer();
        }
    }

    void CompleteGoal()
    {
        if (Score.count == 10)
        {
            TimerManager.StopTimer();
        }
    }
}
