using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForDuplicatePlayer : MonoBehaviour
{
    public string targetTag = "Player"; // Promenite "YourTag" na željeni tag
    public Transform spawnPositionReference; // Referenca na prazan GameObject sa pozicijom

    private void Awake()
    {
        GameObject[] existingObjects = GameObject.FindGameObjectsWithTag(targetTag);

        if (existingObjects.Length > 1)
        {
            Destroy(gameObject);
        }

        //Spawn
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject taggedObject in taggedObjects)
        {
            taggedObject.transform.position = spawnPositionReference.position;
        }
    }
}
