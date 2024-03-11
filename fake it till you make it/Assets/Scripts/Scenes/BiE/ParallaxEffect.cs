using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxMult;

    private Vector2 startPos;
    private PixelPerfectCamera pixelPerfect;

    private void Start()
    {
        pixelPerfect = Camera.main.GetComponent<PixelPerfectCamera>();
        startPos = pixelPerfect.RoundToPixel(transform.position);
    }

    private void Update()
    {
        Vector2 cameraOffset = pixelPerfect.RoundToPixel(pixelPerfect.transform.position);
        Vector2 pos = pixelPerfect.RoundToPixel(startPos + cameraOffset * parallaxMult);
        transform.position = new Vector3(pos.x - 10, pos.y - 5, transform.position.z);
    }
}
