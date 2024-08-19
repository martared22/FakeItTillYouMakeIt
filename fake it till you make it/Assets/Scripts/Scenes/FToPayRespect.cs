using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FToPayRespect : MonoBehaviour
{
    public GameObject fSpritePrefab; // Assign the prefab in the Inspector
    private DoorScript doorScript;
    private GameObject letterF;
    private SpriteRenderer sprite;

    private void Start()
    {
        doorScript = GetComponent<DoorScript>();
        sprite = GetComponent<SpriteRenderer>();
        if (fSpritePrefab != null)
        {
            letterF = Instantiate(fSpritePrefab, this.transform);

            if (sprite != null && sprite.sprite != null)
            {

                Vector3 lowestPoint = new(sprite.bounds.center.x, sprite.bounds.max.y, transform.position.z);
                letterF.transform.position = new Vector3(lowestPoint.x, lowestPoint.y + 0.8f, lowestPoint.z);
            }
            else
            {
                letterF.transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            }
            letterF.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (doorScript == null)
            {
                if (letterF != null)
                {
                    letterF.SetActive(true);
                }
            } 
            else
            {
                if (letterF != null && !GameManager.Instance.GetLevelCompletionStatus(doorScript.sceneName))
                {
                    letterF.SetActive(true);
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (letterF != null)
            {
                letterF.SetActive(false);
            }
        }
    }
}
