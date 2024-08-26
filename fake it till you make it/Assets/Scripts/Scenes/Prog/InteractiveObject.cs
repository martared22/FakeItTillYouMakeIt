using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public Sprite correctKeySprite;
    public GameObject requiredKey;
    public GameObject interactableObject;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D objectCollider;

    public Vector3 correctKeySpriteOffset;
    public ProgLevelController controller;

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
                spriteRenderer.sprite = correctKeySprite;
                AdjustColliderToSprite();
                transform.position += correctKeySpriteOffset;
                
                objectCollider.isTrigger = false;
                interactableObject.layer = LayerMask.NameToLayer("Ground");

                Debug.Log("Interaction successful: Correct key used!");
            }
            else
            {
                controller.GetFails();
                Debug.Log("Interaction failed: Incorrect key!");
            }
        }
    }
    void AdjustColliderToSprite()
    {
        if (spriteRenderer.sprite != null)
        {
            Bounds spriteBounds = spriteRenderer.sprite.bounds;
            objectCollider.size = spriteBounds.size;
            objectCollider.offset = spriteBounds.center;
        }
    }
}
