using UnityEngine;
using System;

public class SlotsPanel : MonoBehaviour
{
    ItemSlot[] activeSlots;

    public event Action<ItemSlot> OnPointerClickEvent;
    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    private void Awake()
    {
        activeSlots = GetComponentsInChildren<ItemSlot>();
    }
    private void Start()
    {
        foreach(var itemSlot in activeSlots)
        {
            itemSlot.OnPointerClickEvent += OnPointerClickEvent;
            itemSlot.OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlot.OnPointerExitEvent += OnPointerExitEvent;
            itemSlot.OnBeginDragEvent += OnBeginDragEvent;
            itemSlot.OnEndDragEvent += OnEndDragEvent;
            itemSlot.OnDragEvent += OnDragEvent;
            itemSlot.OnDropEvent += OnDropEvent; 
        }
    }
    public ItemSlot FindEmptySlot()
    {
        foreach(var itemSlot in activeSlots)
        {
            if (itemSlot.IsEmpty()) return itemSlot;
        }
        return null;
    }
}
