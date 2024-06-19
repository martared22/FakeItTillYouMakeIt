using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int level;
    public Color color;
    public Color platformColor;
    public PlatformGenerator platformGenerator; // Reference to the platform generator
    public GameObject player; // Reference to the player GameObject

    public void Initialize(int level, Color color, PlatformGenerator generator, GameObject player)
    {
        this.level = level;
        this.color = color;
        this.platformGenerator = generator;
        this.player = player;
        GetComponent<Renderer>().material.color = color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player playerCheck = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject == player && playerCheck.CheckIfGrounded())
        {
            // Deactivate other platforms on the same level
            platformGenerator.DeactivateOtherPlatforms(level, this);
            SetPlatformColor();
        }
    }

    private Color SetPlatformColor() {
        return color;
    }
}

