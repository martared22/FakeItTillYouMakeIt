using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlatformInfo
{
    public int level;
    public int index;
    public Color color;

    public PlatformInfo(int level, int index, Color color)
    {
        this.level = level;
        this.index = index;
        this.color = color;
    }
}

public class Platform : MonoBehaviour
{
    public PlatformInfo platformInfo;
    public PlatformGenerator platformGenerator;
    public bool isComplementary;
    public GameObject player;
    public GameObject lava;
    private Color[] colors;
    private Dictionary<Color, Color> complementaryColors;

    void Start()
    {
        colors = new Color[6];
        colors[0] = new Color(1.0f, 0f, 0f); //red
        colors[1] = new Color(0f, 1f, 0f); //green
        colors[2] = new Color(0f, 0f, 1.0f); //blue
        colors[3] = new Color(1.0f, 1.0f, 0f);  //orange   
        colors[4] = new Color(1.0f, 0.5f, 0f); //yellow
        colors[5] = new Color(0.49f, 0f, 1f); //purple

        complementaryColors = new Dictionary<Color, Color>
        {
            { colors[0], colors[1] }, // Red -> Green
            { colors[1], colors[0] }, // Green -> Red
            { colors[2], colors[3] }, // Blue -> Orange
            { colors[3], colors[2] }, // Orange -> Blue
            { colors[4], colors[5] }, // Yellow -> Purple
            { colors[5], colors[4] }  // Purple -> Yellow
        };
    }

    public void Initialize(int level, int index, Color color, PlatformGenerator generator, GameObject player, GameObject lava, bool isComplementary)
    {
        platformInfo = new PlatformInfo(level, index, color);
        this.platformGenerator = generator;
        this.player = player;
        this.lava = lava;
        this.isComplementary = isComplementary;
        GetComponent<Renderer>().material.color = color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player playerCheck = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject == player && playerCheck.CheckIfGrounded())
        {
            platformGenerator.DeactivateOtherPlatforms(platformInfo.level, this);
            if(!isComplementary)
            {
                if (!ColorsMatch(platformInfo.color, lava.GetComponent<Renderer>().material.color))
                {
                    RemovePlatform();
                }
            }
            else
            {
                Color tempColor = GetComplementaryColor(platformInfo.color);
                if (!ColorsMatch(tempColor, lava.GetComponent<Renderer>().material.color))
                {
                    RemovePlatform();
                }
            }
            
        }
    }
    private bool ColorsMatch(Color color1, Color color2)
    {
        return color1.Equals(color2);
    }

    public Color GetComplementaryColor(Color color)
    {
        if (complementaryColors.ContainsKey(color))
        {
            return complementaryColors[color];
        }
        return Color.black;
    }

    private void RemovePlatform()
    {
        gameObject.SetActive(false);
    }
}

