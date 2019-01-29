using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, ISubmitHandler
{
    [SerializeField]
    Item item;

    public void OnValidate()
    {
        item = GetComponentInChildren<Item>();
    }
    public void OnSubmit(BaseEventData eventData)
    {
        if(item != null)
        {
            item.SelectItem();
        }
    }
    
}

