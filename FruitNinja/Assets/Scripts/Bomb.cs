using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Whenever we hit the bomb, we want to see if the blade hits us
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b) return;

        FindObjectOfType<GameManager>().OnBombHit();
    }
}
