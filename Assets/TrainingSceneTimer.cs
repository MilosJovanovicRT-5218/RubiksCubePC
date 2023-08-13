using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainingSceneTimer : MonoBehaviour
{
    private bool timerRunning = false;
    private float currentTime = 0f;

    public TMP_Text timer;
    public TMP_Text scramble;

    private List<string> moves = new List<string> { "R", "M", "R'", "M'", "U", "L", "U'", "L'", "B", "D", "B'", "D'" };
    private string currentScramble = "";

    private bool isVisible = true; // Poèetno podešavanje je "true"

    private void Start()
    {
        GenerateScramble();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!timerRunning)
            {
                timerRunning = true;
                currentTime = 0f;
                GenerateScramble();
            }
            else
            {
                timerRunning = false;
            }
        }

        if (timerRunning)
        {
            currentTime += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            timerRunning = false;
            currentTime = 0f;
        }

        DisplayTime();

        //OnnOffButton
        // Provera da li je pritisnut taster "O"
        if (Input.GetKeyDown(KeyCode.O))
        {
            // Promeni vrednost isVisible
            isVisible = !isVisible;

            // Postavi vidljivost tekstualnih komponenti na osnovu isVisible
            timer.gameObject.SetActive(isVisible);
            scramble.gameObject.SetActive(isVisible);
        }
    }

    private void GenerateScramble()
    {
        currentScramble = "";
        for (int i = 0; i < 18; i++)
        {
            int randomIndex = Random.Range(0, moves.Count);
            currentScramble += moves[randomIndex] + " ";
        }
        scramble.text = currentScramble;
    }

    private void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        float milliseconds = Mathf.Floor((currentTime - Mathf.Floor(currentTime)) * 1000);

        string timeText = minutes.ToString("00") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("000");
        timer.text = timeText;
    }
}
