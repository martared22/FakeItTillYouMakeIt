using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject player;

    public int numberOfLevels = 6;
    public int platformsPerLevel = 3;
    public int level = 0;
    public float verticalSpacing = 6.0f;
    public float horizontalSpacing = 8.0f;

    private Color[] colors;

    void Start()
    {
        colors = new Color[6];
        colors[0] = new Color(1.0f, 0f, 0f); 
        colors[1] = new Color(0f, 1f, 0f); 
        colors[2] = new Color(0f, 0f, 1.0f); 
        colors[3] = new Color(1.0f, 1.0f, 0f);
        colors[4] = new Color(1.0f, 0.5f, 0f); 
        colors[5] = new Color(0.49f, 0f, 1f); 

        GeneratePlatforms();
    }

    void GeneratePlatforms()
    {
        for (int level = 0; level < numberOfLevels; level++)
        {
            for (int i = 0; i < platformsPerLevel; i++)
            {
                Vector3 position = new Vector3(i * horizontalSpacing, level * verticalSpacing, 0);

                // Instantiate the platform
                GameObject platform = Instantiate(platformPrefab, position, Quaternion.identity);

                // Get the Platform script component and initialize it
                Platform platformScript = platform.GetComponent<Platform>();
                if (platformScript != null)
                {
                    platformScript.Initialize(level, colors[(level + i) % colors.Length], this, player);
                }

                // Parent the platform to keep the hierarchy clean (optional)
                platform.transform.parent = this.transform;
            }
        }
    }

    public void DeactivateOtherPlatforms(int level, Platform currentPlatform)
    {
        foreach (Transform platform in transform)
        {
            Platform platformScript = platform.GetComponent<Platform>();
            if (platformScript != null && platformScript != currentPlatform && platformScript.level == level)
            {
                platform.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
