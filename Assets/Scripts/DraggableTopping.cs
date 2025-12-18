using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableTopping : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 pointerOffset;
    public ToppingFlags toppingType;

    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 startPos;
    private CanvasGroup canvasGroup;
    public PrepStation prepStation;
    public int toppingIndex;

    public bool droppedSuccessfully;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startPos = rectTransform.anchoredPosition;

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
{
    startPos = rectTransform.anchoredPosition;
    droppedSuccessfully = false;
    canvasGroup.blocksRaycasts = false;

    RectTransformUtility.ScreenPointToLocalPointInRectangle(
        rectTransform,
        eventData.position,
        eventData.pressEventCamera,
        out pointerOffset
    );
}

    public void OnDrag(PointerEventData eventData)
{
    RectTransformUtility.ScreenPointToLocalPointInRectangle(
        rectTransform.parent as RectTransform,
        eventData.position,
        eventData.pressEventCamera,
        out Vector2 localPoint
    );

    rectTransform.anchoredPosition = localPoint - pointerOffset;
}

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (droppedSuccessfully)
        {
            prepStation.ToggleTopping(toppingIndex);
            // Ingredient consumed
            gameObject.SetActive(false);
        }
        else
        {
            // Snap back
            rectTransform.anchoredPosition = startPos;
        }
    }
}
