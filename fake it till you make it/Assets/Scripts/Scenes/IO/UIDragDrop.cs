using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform parentToReturnTo;
    private CanvasGroup canvasGroup;

    public RectTransform designatedArea;  // Assign the designated area in the Inspector

    private bool isInPlace;
    public IoQuizManager ioQuizManager;
    public string notGateIdentifier;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        switch (notGateIdentifier)
        {
            case "not1":
                ioQuizManager.not1 = isInPlace;
                break;
            case "not2":
                ioQuizManager.not2 = isInPlace;
                break;
            case "not3":
                ioQuizManager.not3 = isInPlace;
                break;
            default:
                Debug.LogError("Invalid NOT Gate Identifier");
                break;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsInDesignatedArea())
        {
            this.transform.position = designatedArea.position;
            

        }
        else
        {
            startPosition = this.transform.position;
            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.root);  // Move to the root to avoid being masked by other UI elements
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (IsInDesignatedArea())
        {
            // Snap to the center of the designated area
            this.transform.position = designatedArea.position;
            isInPlace = true;
        }
        else
        {
            // Return to the start position
            this.transform.position = startPosition;
            isInPlace = false;
        }

        this.transform.SetParent(parentToReturnTo);  // Ensure it returns to the original parent
    }

    private bool IsInDesignatedArea()
    {
        return RectTransformUtility.RectangleContainsScreenPoint(designatedArea, Input.mousePosition, null);
    }
}
