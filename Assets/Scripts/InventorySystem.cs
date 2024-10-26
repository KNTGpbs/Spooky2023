using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InventorySystem : MonoBehaviour
{
    private List<ItemData> items = new();
    [SerializeField] private GameObject newItemUI;
    
    public void AddItem(ItemData itemData)
    {
        items.Add(itemData);
        Canvas canvas = GameObject.Find("UITest").GetComponent<Canvas>();
        var newItem = Instantiate(newItemUI);
        newItem.transform.SetParent(canvas.transform.GetChild(0).GetChild(0).GetChild(0), false);
        //newItem.GetComponentInChildren<TextMeshPro>().text = itemData.itemName;
    }

    public void RemoveItem(ItemData itemData) {
        items.Remove(itemData); 
    }

    public void UseItem()
    {
        
    }

    public void TestFunction()
    {
        Debug.Log("Test success");
    }
}
