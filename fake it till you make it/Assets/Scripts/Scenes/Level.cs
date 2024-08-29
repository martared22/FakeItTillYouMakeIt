using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public string name;
    public int starsEarned;
    public bool levelVisited;
    public bool levelFailed;

    public Level(string name)
    {
        this.name = name;
        this.starsEarned = 0;
        this.levelVisited = false;
        this.levelFailed = false;
    }

    public void CheckLevelFailed()
    {
        levelFailed = starsEarned < 3;
    }
}

