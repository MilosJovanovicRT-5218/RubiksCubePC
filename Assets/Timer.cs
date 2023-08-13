using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Transform[] objectsToCheck;
    public Text timerToSolve;

    private Vector3[] initialPositions;
    private bool timerRunning;
    private float timer;

    void Start()
    {
        initialPositions = new Vector3[objectsToCheck.Length];
        for (int i = 0; i < objectsToCheck.Length; i++)
        {
            initialPositions[i] = objectsToCheck[i].position;
        }

        timerRunning = false;
        timer = 0f;
    }

    void Update()
    {
        bool allObjectsReturned = true;

        for (int i = 0; i < objectsToCheck.Length; i++)
        {
            if (Vector3.Distance(objectsToCheck[i].position, initialPositions[i]) > 0.01f)
            {
                allObjectsReturned = false;
                break;
            }
        }

        if (allObjectsReturned)
        {
            timerRunning = false;
        }
        else if (!timerRunning)
        {
            timerRunning = true;
            timer = 0f;
        }

        if (timerRunning)
        {
            timer += Time.deltaTime;

            int minutes = (int)(timer / 60);
            int seconds = (int)(timer % 60);
            int milliseconds = (int)((timer * 1000) % 1000);

            timerToSolve.text = string.Format("Time: {0:0} : {1:0} : {2:000}", minutes, seconds, milliseconds);
        }
    }

    public void Scramble()
    {
  
    }
}
