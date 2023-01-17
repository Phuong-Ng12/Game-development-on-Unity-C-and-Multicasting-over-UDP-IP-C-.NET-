using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        // Take the Rigidbody2D component from the Blade
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Make the Blade follow the mouse
        SetBladeToMouse();
    }

    // Make the Blade follow the mouse
    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10; // distance of 10 units from the camera

        // Change the rigidbody position to world space
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
