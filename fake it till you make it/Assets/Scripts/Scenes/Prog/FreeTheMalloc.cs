using System.Collections;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class FreeTheMalloc : MonoBehaviour
{ 
    public GameObject requiredKey;
    public GameObject interactableObject;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D objectCollider;

    public Vector3 correctKeySpriteOffset;
    public ProgLevelController controller;
    public TextMeshProUGUI errorText;

    void Start()
    {
        controller = FindObjectOfType<ProgLevelController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<BoxCollider2D>();
        objectCollider.isTrigger = true;
        interactableObject.layer = LayerMask.NameToLayer("Default");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MultiKeyPickup playerKeyScript = other.GetComponent<MultiKeyPickup>();
            GameObject playerKey = playerKeyScript.GetCurrentKey();

            if (playerKey == requiredKey)
            {
                Debug.Log("Interaction successful: Correct key used!");
                StartCoroutine(FreeMalloc());
            }
            else
            {
                StartCoroutine(ShowMallocMessage());
            }
        }
    }
    private IEnumerator ShowMallocMessage()
    {
        errorText.text = "I don't think this is the right key love.";
        yield return new WaitForSeconds(2f);
        errorText.text = "";
    }

    private IEnumerator FreeMalloc()
    {
        errorText.text = "Thank you so much. Good luck with your exams cutie!";
        controller.isFree = true;
        yield return new WaitForSeconds(2f);
        errorText.text = "";
        PlayerPrefs.SetInt("LevelVisited_" + "Prog", 1);
        PlayerPrefs.SetInt("completed", true ? 1 : 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("PopupScene");
    }
}
