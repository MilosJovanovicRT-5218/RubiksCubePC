using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Solve3x3"); 
    }

    public void StartTraining()
    {
        SceneManager.LoadScene("Training"); 
    }

    public void StartLearning()
    {
        SceneManager.LoadScene("Learn");
    }

    public void StartChallengeMode()
    {
        SceneManager.LoadScene("Level1");
    }

    public void StartMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Update()
    {
        Cursor.visible = true; // Postavlja vidljivost mi�a na 'true'
        Cursor.lockState = CursorLockMode.None; // Otklju�ava mi�a da se mo�e slobodno kretati
    }
}
