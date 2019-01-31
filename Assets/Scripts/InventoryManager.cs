using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    public SlotsPanel activePanel, inventoryPanel;

    ItemSlot draggedFromSlot;

    [SerializeField]
    Image draggeableImage;
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
        if (itemSlot.Item != null) //Check if slot has an item
        {
            if (itemSlot.transform.parent == activePanel.transform) //Check what panel it is in
            {
                if (inventoryPanel.isActiveAndEnabled)
                {
                    ItemSlot iS = inventoryPanel.FindEmptySlot(); //Find a Empty slot in the panel where the item will be transferred
                    if (iS != null) //Check to see if there is an empty slot
                    {
                        iS.Item = itemSlot.Item; // Add item to slot

                        itemSlot.Item.transform.SetParent(iS.transform); // Change items parent to said empty slot
                        itemSlot.Item.transform.localPosition = Vector3.zero; // Change its local position to be on center of the slot
                        itemSlot.Item = null; //Null the slot of an item
                    }
                }
            }
            //Same as above but for the other panel
            if (itemSlot.transform.parent == inventoryPanel.transform)
            {
                if (activePanel.isActiveAndEnabled)
                {
                    ItemSlot iS = activePanel.FindEmptySlot();
                    if (iS != null)
                    {
                        iS.Item = itemSlot.Item;

                        itemSlot.Item.transform.SetParent(iS.transform);
                        itemSlot.Item.transform.localPosition = Vector3.zero;
                        itemSlot.Item = null;
                    }
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
        if (itemSlot.Item != null) // Check to see if slot has an item
        {
            draggedFromSlot = itemSlot;
            draggeableImage.sprite = itemSlot.Item.itemIcon;
            draggeableImage.color = Color.white;
            draggeableImage.transform.position = Input.mousePosition;
            itemSlot.Item.transform.localPosition = Input.mousePosition;
        }
    }
    public void EndDrag(ItemSlot itemSlot) //This is the frame when drag is ended
    {
        draggeableImage.color = new Color(1, 1, 1, 0);
        draggeableImage.sprite = null;
        draggedFromSlot = null;
    }
    public void Drag(ItemSlot itemSlot) // This is the while a slot is being dragged
    {

        if (itemSlot.Item != null)
        {
            draggeableImage.transform.position = Input.mousePosition;
            itemSlot.Item.transform.position = Input.mousePosition;
        }
    }
    public void Drop(ItemSlot droppedItemSlot) // this is the slot that we are dropping items in
    {
        //Store a ref in a local variable
        Item item = draggedFromSlot.Item;
        //Swap items with droppedItemSlot
        draggedFromSlot.Item = droppedItemSlot.Item;
        //Check to see if droppedItemSlot has an item to reparent
        if (droppedItemSlot.Item != null)
        {
            droppedItemSlot.Item.transform.parent = draggedFromSlot.transform;
            droppedItemSlot.Item.transform.localPosition = Vector3.zero;
        }
        //Swap items with temporary item
        droppedItemSlot.Item = item;
        //Reparent Item location

        item.transform.SetParent(droppedItemSlot.transform);
        item.transform.localPosition = Vector3.zero;
    }
}
