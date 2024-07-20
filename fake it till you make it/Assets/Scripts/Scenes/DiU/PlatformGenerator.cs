using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject player;
    public GameObject lava;

    public int numberOfLevels = 10;
    public int additionalPlatformsCount = 10;
    public int platformsPerLevel = 3;
    public int level = 0;
    public int index = 0;
    public float verticalSpacing = 6.0f;
    public float horizontalSpacing = 8.0f;

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

        GeneratePlatforms();
    }

    public void GeneratePlatforms()
    {
        for (int level = 0; level < numberOfLevels; level++)
        {
            GenerateLevelPlatforms(level);
        }
    }

    public void GenerateLevelPlatforms(int level){
        Color levelColor = colors[level % colors.Length];

        int specialPlatformIndex = Random.Range(0, platformsPerLevel);

        for (int i = 0; i < platformsPerLevel; i++)
        {
            Vector3 position = new Vector3(i * horizontalSpacing, level * verticalSpacing, 0);
            GameObject platform = Instantiate(platformPrefab, position, Quaternion.identity);

            Platform platformScript = platform.GetComponent<Platform>();
            if (platformScript != null)
            {
                Color platformColor = (i == specialPlatformIndex) ? levelColor : GetRandomColorExcluding(levelColor);
                platformScript.Initialize(level, i, platformColor, this, player, lava, false);
            }
            platform.transform.parent = this.transform;
        }
    }

    private Color GetRandomColorExcluding(Color excludeColor)
    {
        Color randomColor;
        do
        {
            randomColor = colors[Random.Range(0, colors.Length)];
        } while (randomColor == excludeColor);

        return randomColor;
    }

    public void GenerateAdditionalPlatforms()
    {
        int startingLevel = numberOfLevels;
        numberOfLevels += additionalPlatformsCount;
        Color levelColor = colors[level % colors.Length];
        Color tempColor = GetComplementaryColor(levelColor);

        for (int level = startingLevel; level < numberOfLevels; level++)
        {
            GenerateLevelPlatformsWithComplementaryColor(level, tempColor);
        }
    }
    public Color GetComplementaryColor(Color color)
    {
        if (complementaryColors.ContainsKey(color))
        {
            return complementaryColors[color];
        }
        return Color.black;
    }

    private void GenerateLevelPlatformsWithComplementaryColor(int level, Color complementaryColor)
    {
        int specialPlatformIndex = Random.Range(0, platformsPerLevel);

        for (int i = 0; i < platformsPerLevel; i++)
        {
            Vector3 position = new Vector3(i * horizontalSpacing, level * verticalSpacing, 0);
            GameObject platform = Instantiate(platformPrefab, position, Quaternion.identity);

            Platform platformScript = platform.GetComponent<Platform>();
            if (platformScript != null)
            {
                Color platformColor = (i == specialPlatformIndex) ? complementaryColor : GetRandomColorExcluding(complementaryColor);
                platformScript.Initialize(level, i, platformColor, this, player, lava, true);
            }
            platform.transform.parent = this.transform;
        }
    }

    public void DeactivateOtherPlatforms(int level, Platform currentPlatform)
    {
        foreach (Transform platform in transform)
        {
            Platform platformScript = platform.GetComponent<Platform>();
            if (platformScript != null && platformScript != currentPlatform && platformScript.platformInfo.level == level)
            {
                platform.gameObject.SetActive(false);
            }
        }
    }
}
