using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{ 
    public SpriteRenderer lights;
    public SpriteRenderer proyector;
    public SpriteRenderer screen;
    public SpriteRenderer activatableSwitch;

    public IoQuizManager ioQuizManager;

    void Start()
    {
        ioQuizManager = FindObjectOfType<IoQuizManager>();
    }

    void Update()
    {
        UpdateSprite();
    }

    void UpdateSprite()
    {
        activatableSwitch.enabled = ioQuizManager.activationSwitch;
        lights.enabled = ioQuizManager.lights;
        proyector.enabled = ioQuizManager.projector;
        screen.enabled = ioQuizManager.screen;
    }
}

