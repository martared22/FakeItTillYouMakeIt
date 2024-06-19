using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public Color[] colors;
    private Renderer objectRenderer;
    private int currentColorIndex = 0;

    public float riseSpeed = 2f;

    void Start()
    {
        colors = new Color[6];
        colors[0] = new Color(1.0f, 0f, 0f);
        colors[1] = new Color(0f, 1f, 0f);
        colors[2] = new Color(0f, 0f, 1.0f);
        colors[3] = new Color(1.0f, 1.0f, 0f);
        colors[4] = new Color(1.0f, 0.5f, 0f);
        colors[5] = new Color(0.49f, 0f, 1f);

        // Get the Renderer component of the object
        objectRenderer = GetComponent<Renderer>();

        // Start the coroutine to change colors
        StartCoroutine(ChangeColor());
    }
    IEnumerator ChangeColor()
    {
        while (true)
        {
            // Change the object's color to the current color in the array
            objectRenderer.material.color = colors[currentColorIndex];

            // Move to the next color, wrapping around if necessary
            currentColorIndex = (currentColorIndex + 1) % colors.Length;

            // Wait for 1 second
            yield return new WaitForSeconds(2f);
        }
    }
    private void Update()
    {
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
    }
}
