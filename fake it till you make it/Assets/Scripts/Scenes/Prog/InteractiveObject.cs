using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public Sprite correctKeySprite;
    public GameObject requiredKey;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D objectCollider;

    public Vector3 correctKeySpriteOffset;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<BoxCollider2D>();

        objectCollider.isTrigger = true;
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

                Debug.Log("Interaction successful: Correct key used!");
            }
            else
            {
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
