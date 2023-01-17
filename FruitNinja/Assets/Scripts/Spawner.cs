using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // The fruit we want to throw/spawn to the scene (banana, orange, etc.)
    public GameObject[] objectToSpawn;

    public GameObject bomb;

    // Each fruit has different spawned place. The spawner needs to know the spawned places.
    public Transform[] spawnPlaces;

    // Know the time we have between different fruit that 
    // will be spawned 
    public float minWait = 0.3f;
    public float maxWait = 1f;

    // The force of spawning the fruit
    public float minForce = 12;
    public float maxForce = 17;

    // Start is called before the first frame update
    // Start a routine that constantly create fruits
    // after the wait time [minWait, maxWait]
    void Start()
    {
        // This needs an IEnumerator in order to start anything
        StartCoroutine(SpawnFruits());
    }

    // Throws fruits
    private IEnumerator SpawnFruits()
    {
        // As long as the StartCoroutine runs, we want to spawn fruits
        while (true)
        {
            // Do sth after an amount of time
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            // Transform the position of the fruit we created
            // The places will be between the first spawn place and the last spawn place
            // e.g we have 3 spawn places | | |, the fruit will be spawned between the
            // 1st | and the last |
            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject go = null;
            float p = Random.Range(0, 100);

            if (p < 10)
            {
                go = bomb;
            } else
            {
                go = objectToSpawn[Random.Range(0, objectToSpawn.Length)];
            }

            // Create the fruit to spawn at the position t with rotation t
            GameObject fruit = Instantiate(go, t.position, t.rotation);

            // Add force to the fruit to make it fly to the air
            // Apply the force to the fruit mode: t.transform.up * 10
            // Force the fruit up : ForceMode2D.Impulse
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);

            Debug.Log("Fruit gets spawned.");

            // Destroy the fruit after 5 seconds
            Destroy(fruit, 5);
        }
    }

}
