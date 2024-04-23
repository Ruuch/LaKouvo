using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIPSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn; // Assign this in the inspector
    [SerializeField] private float spawnInterval = 10.0f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // Decrease the timer each frame

        if (timer <= 0)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation); // Spawn the object
            timer = spawnInterval; // Reset the timer
        }
    }
}
