using System;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

//[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemEntry : MonoBehaviour
{
    public ItemData item;
    //public UnityAction useAction;
    public InventorySystem inventorySystem;

    public ItemData Item
    {
        get => item;
        set {
            if (item != null)
                throw new InvalidOperationException("Item already set");
            item = value;
            //this.useAction += Use;
        }
    }

    /*public void Use()
    {
        if (item?.furniture.GetComponent<FurnitureLogic>().GetFlag() ?? false)
        {
            if (GameObject.Find("PlayerTest").GetComponent<PlayerMovement>().GetTurnedToBG())
            {
                Debug.Log($"Item {item.itemName} is used");
                item.itemEvent.Invoke();
            }
        }
    }*/

    public void ItemData_clicked()
    {
        inventorySystem.UseItem(this);
    }

    public void NoteData_clicked()
    {
        inventorySystem.UseItem(this);
    }
}