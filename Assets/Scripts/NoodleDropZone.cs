using UnityEngine;
using UnityEngine.EventSystems;

public class NoodleDropZone : MonoBehaviour, IDropHandler
{
    private PrepStation prepStation;

    private void EnsurePrepStation()
    {
        if (prepStation == null)
        {
            prepStation = FindFirstObjectByType<PrepStation>(
                FindObjectsInactive.Include
            );
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        EnsurePrepStation();

        DraggableTopping topping =
            eventData.pointerDrag?.GetComponent<DraggableTopping>();

        if (topping == null || prepStation == null)
            return;

        //prepStation.ToggleTopping((int)topping.toppingType);
        topping.droppedSuccessfully = true;
    }
}
