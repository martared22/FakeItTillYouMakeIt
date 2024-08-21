using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class MultiKeyPickup : MonoBehaviour
{
    public GameObject[] keysInWorld;
    public Sprite[] keySprites;
    public string[] keyTexts;

    public GameObject keyUIImage;
    public TextMeshProUGUI keyUIText;

    private GameObject currentKey = null;
    private GameObject previousKey = null;

    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();

    void Start()
    {
        keyUIImage.SetActive(false);
        keyUIText.gameObject.SetActive(false);

        foreach (GameObject key in keysInWorld)
        {
            originalPositions[key] = key.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            PickUpKey(other.gameObject);
        }
    }

    void PickUpKey(GameObject newKey)
    {
        if (currentKey != null)
        {
            ReturnPreviousKey();
        }

        currentKey = newKey;
        int keyIndex = System.Array.IndexOf(keysInWorld, newKey);

        if (keyIndex != -1)
        {
            UpdateUI(keyIndex);
        }

        newKey.SetActive(false);
        previousKey = currentKey;
    }

    void UpdateUI(int keyIndex)
    {
        keyUIImage.SetActive(true);
        keyUIText.gameObject.SetActive(true);
        keyUIImage.GetComponent<Image>().sprite = keySprites[keyIndex];
        keyUIText.text = keyTexts[keyIndex];
    }

    void ReturnPreviousKey()
    {
        if (previousKey != null)
        {
            previousKey.SetActive(true);
            previousKey.transform.position = originalPositions[previousKey];
        }

        previousKey = null;
    }

    public GameObject GetCurrentKey()
    {
        return currentKey;
    }
}
