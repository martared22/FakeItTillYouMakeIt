using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private float defaultVerticalOffset = 0f;

    void LateUpdate()
    {
        if (target != null)
        {
            float verticalOffset = GetVerticalOffsetForScene(SceneManager.GetActiveScene().name);
            Vector3 newPosition = new Vector3(target.position.x, target.position.y + verticalOffset, transform.position.z);
            transform.position = newPosition;
        }
    }

    float GetVerticalOffsetForScene(string sceneName)
    {
        if (sceneName == "BiE")
        {
            return 6f;
        } else if (sceneName == "Algebra")
        {
            return 5f;
        }
        else 
        {
            return defaultVerticalOffset;
        }
    }
}