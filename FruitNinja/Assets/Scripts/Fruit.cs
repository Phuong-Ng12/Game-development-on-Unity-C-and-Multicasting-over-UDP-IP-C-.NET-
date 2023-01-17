using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // As soon as we cut the orange, we want the orange species
    // that will fall off into two different directions.
    // We want this for all the fruits.

    // GameObject : holds the fruit script

    public GameObject slicedFruitPrefab;

    /*
    // Update method for user input
    private void Update()
    {
        // As soon as user presses space key, create sliced fruit
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Fruit sliced.");
            CreateSlicedFruit();
        }
    }
    */

    // Method that sliced the fruit
    public void CreateSlicedFruit()
    {
        // Instantiate the sliced fruit, at the same position as our original fruit,
        // and transform the rotation, same rotation that we have.
        GameObject inst = (GameObject) Instantiate(slicedFruitPrefab, transform.position, transform.rotation);


        // Create rotation after slicing the fruit
        Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        // Go through all of the different slice of species of the fruit
        foreach(Rigidbody r in rbsOnSliced)
        {
            // Transform each of the sliced fruit with a random rotation
            r.transform.rotation = Random.rotation;

            // Add explosion so the fruit species will be blasted to different directions after slicing
            // how powerful should the explosion force be : Random.Range(500, 1000)
            // where the explosion should start : transform.position
            // explosion radius : 5f
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }

        // Increase the score when fruit is sliced
        FindObjectOfType<GameManager>().IncreaseScore(3);

        // Destroy the sliced fruit
        Destroy(inst.gameObject, 5);

        // Destroy the original whole fruit
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b) return;

        CreateSlicedFruit();
    }
}
