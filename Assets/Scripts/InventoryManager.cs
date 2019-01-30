using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public SlotsPanel activePanel, inventoryPanel;

    ItemSlot draggedFromSlot;

    private void Awake()
    {
        //Setup Events
        //Click Events
        activePanel.OnPointerClickEvent += Equip;
        inventoryPanel.OnPointerClickEvent += Equip;
        //On cursor enter
        activePanel.OnPointerEnterEvent += ShowToolTip;
        inventoryPanel.OnPointerEnterEvent += ShowToolTip;
        // On cursor exit
        activePanel.OnPointerExitEvent += HideToolTip;
        inventoryPanel.OnPointerExitEvent += HideToolTip;
        //On Drag Begin
        activePanel.OnBeginDragEvent += BeginDrag;
        inventoryPanel.OnBeginDragEvent += BeginDrag;
        //On Drag End
        activePanel.OnEndDragEvent += EndDrag;
        inventoryPanel.OnEndDragEvent += EndDrag;
        //On Drag
        activePanel.OnDragEvent += Drag;
        inventoryPanel.OnDragEvent += Drag;
        //On Drop 
        activePanel.OnDropEvent += Drop;
        inventoryPanel.OnDropEvent += Drop;

    }


    public void Equip(ItemSlot itemSlot) // On right clicking a item slot
    {
        if(itemSlot.Item != null)
        {
            if(itemSlot.transform.parent == activePanel.transform)
            {
                ItemSlot iS = inventoryPanel.FindEmptySlot();
                if(iS !=null)
                {
                    iS.Item = itemSlot.Item;
                    itemSlot.Item.transform.parent = iS.transform;
                    itemSlot.Item.transform.position = Vector3.zero;
                    itemSlot.Item = null;
                }
            }
            if(itemSlot.transform.parent == inventoryPanel.transform)
            {
                
                ItemSlot iS = activePanel.FindEmptySlot();
                if(iS != null)
                {
                    iS.Item = itemSlot.Item;
                    itemSlot.Item.transform.parent = iS.transform;
                    itemSlot.Item.transform.position = Vector3.zero;
                    itemSlot.Item = null;
                }
            }
        }
    }
    public void ShowToolTip(ItemSlot itemSlot) // When entering item slot
    {

    }
    public void HideToolTip(ItemSlot itemSlot) // When exiting item slot
    {

    }
    public void BeginDrag(ItemSlot itemSlot) // This is the frame when drag is starting
    {
        if(itemSlot.Item != null)
        {
            draggedFromSlot = itemSlot;
            itemSlot.Item.transform.position = Input.mousePosition;
        }
    }
    public void EndDrag(ItemSlot itemSlot) //This is the frame when drag is ended
    {
        draggedFromSlot = null;
    }
    public void Drag(ItemSlot itemSlot) // This is the while a slot is being dragged
    {
        if(itemSlot.Item != null)
        itemSlot.Item.transform.position = Input.mousePosition;
    }
    public void Drop(ItemSlot droppedItemSlot) // this is the slot that we are dropping items in
    {
        //Store a ref in a local variable
        Item item = draggedFromSlot.Item;
        //Swap items with droppedItemSlot
        draggedFromSlot.Item = droppedItemSlot.Item;
        //Check to see if droppedItemSlot has an item to reparent
        if(droppedItemSlot.Item != null)
        {
            droppedItemSlot.Item.transform.parent = draggedFromSlot.transform;
        }
        //Swap items with temporary item
        droppedItemSlot.Item = item;
        //Reparent Item location
        item.transform.parent = droppedItemSlot.transform;
    }
}
