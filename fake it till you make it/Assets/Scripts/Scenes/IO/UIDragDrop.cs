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

    void Start()
    {
        startPosition = this.transform.position;
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
            this.transform.SetParent(this.transform.root);
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
            this.transform.position = designatedArea.position;
            isInPlace = true;
        }
        else
        {
            this.transform.position = startPosition;
            isInPlace = false;
        }

        this.transform.SetParent(parentToReturnTo);
    }

    private bool IsInDesignatedArea()
    {
        return RectTransformUtility.RectangleContainsScreenPoint(designatedArea, Input.mousePosition, null);
    }
    public void ResetPosition()
    {
        this.transform.position = startPosition;
        isInPlace = false;
    }
}
