using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    public Color[] colors;
    private Renderer objectRenderer;
    private int currentColorIndex = 0;
    public GameObject player;
    public float riseSpeed = 0.1f;
    public float distanceY;
    public bool isLevel2 = false;

    private const float maxDistance = 30f;

    void Start()
    {
        colors = new Color[6];
        colors[0] = new Color(1.0f, 0f, 0f);
        colors[1] = new Color(0f, 1f, 0f);
        colors[2] = new Color(0f, 0f, 1.0f);
        colors[3] = new Color(1.0f, 1.0f, 0f);
        colors[4] = new Color(1.0f, 0.5f, 0f);
        colors[5] = new Color(0.49f, 0f, 1f);

        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            objectRenderer.material.color = colors[currentColorIndex];
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            yield return new WaitForSeconds(3f);
        }
    }
    private void Update()
    {
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
        AdjustPosition();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void AdjustPosition()
    {
        distanceY = Mathf.Abs(player.transform.position.y - transform.position.y);
        if (distanceY > maxDistance)
        {
            float directionY = Mathf.Sign(player.transform.position.y - transform.position.y);
            transform.position = new Vector3(transform.position.x, player.transform.position.y - (directionY * maxDistance), transform.position.z);
        }
    }
}
