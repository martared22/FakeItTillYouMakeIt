using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionRestorer : MonoBehaviour
{
    string previousScene;

    void Start()
    {
        if (GameManager.Instance.lastPlayerPosition != 0)
        {
            transform.position = new Vector3 (GameManager.Instance.lastPlayerPosition, (float)-1.89, 0);
        }
    }
}
