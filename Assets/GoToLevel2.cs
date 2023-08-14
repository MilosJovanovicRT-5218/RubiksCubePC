using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel2 : MonoBehaviour
{
    public string scene = "Level2";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(scene);
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
