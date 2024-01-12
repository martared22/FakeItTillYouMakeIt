using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerReference;
    public float playerOffset = 10f;
    void Update()
    {
        if (playerReference != null)
        {

            transform.position = new Vector3(playerReference.position.x, playerReference.position.y, -10);
        }
    }
}