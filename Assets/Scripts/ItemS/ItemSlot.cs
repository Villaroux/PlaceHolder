using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ItemSlot : MonoBehaviour, ISubmitHandler, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField]
    Item item;

    Image image;

    private Color disabledImage = new Color(1, 1, 1, 0);
    private Color shownImage = Color.white;
    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item == null)
            {
                image.color = disabledImage;
            }
            else
            {
                image.sprite = value.itemIcon;
                image.color = shownImage;
            }
        }
    }
    public event Action<ItemSlot> OnPointerClickEvent;
    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    public void OnValidate()
    {
        image = GetComponent<Image>();

        item = GetComponentInChildren<Item>();

        Item = item;
   
    }
    private void Start()
    {
        image = GetComponent<Image>();

        item = GetComponentInChildren<Item>();

        Item = item;
    }

    public bool IsEmpty()
    {
        return item == null;
    }
    #region // InterfaceImplementation
    public void OnSubmit(BaseEventData eventData)
    {
        if (item != null)
        {
            item.SelectItem();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnPointerEnterEvent != null)
        {
            OnPointerEnterEvent(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragEvent != null)
        {
            OnBeginDragEvent(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragEvent != null)
        {
            OnEndDragEvent(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
        {
            OnDragEvent(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
        {
            OnDropEvent(this);

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnPointerClickEvent != null && eventData.button == PointerEventData.InputButton.Right)
        {
            OnPointerClickEvent(this);
        }
    }
    #endregion
}

