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
}
