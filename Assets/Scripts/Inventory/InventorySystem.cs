using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.Events;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<ItemData> items = new();
    private int count = 0;
    private List<GameObject> anchors = new();
    [SerializeField] private GameObject anchorsGameObject;
    [SerializeField] private GameObject newItemUI;
    [SerializeField] private GameObject newNoteUI;
    public ItemTarget? currentTargetObject;
    public SanityController sanityController;
    public UI_NoteDisplay noteDisplay;

    private void Start()
    {
        foreach (Transform child in anchorsGameObject.transform)
        {
            anchors.Add(child.GameObject());
        };
        anchorsGameObject.transform.parent.gameObject.SetActive(false);
    }

    public void AddItem(ItemData item)
    {
        GameObject newItem;
        if (item is Note)
        {
            newItem = Instantiate(newNoteUI);
        }
        else
        {
            newItem = Instantiate(newItemUI);
        }
        var entry = newItem.GetComponent<ItemEntry>();
        entry.Item = item;
        entry.inventorySystem = this;
        items.Add(item);
        newItem.transform.SetParent(anchors[count].transform, false);
        newItem.transform.position = anchors[count].transform.position;
        newItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.ItemName;
        count++;
        //newItem.GetComponentInChildren<TextMeshPro>().text = itemData.itemName;
    }

    public void DisplayNote(Note note)
    {
        noteDisplay.ChangeNote(note.Sprite);
    }

    public void RemoveItem(ItemData itemToDelete) {
        items.Remove(itemToDelete);
        foreach (GameObject anchor in anchors)
        {
            if(anchor.transform.GetChild(0).GetComponent<ItemEntry>().item.ItemName == itemToDelete.ItemName)
            {
                Destroy(anchor.transform.GetChild(0).gameObject);
                break;
            }
        }
        count--;
    }

    public void UseItem(ItemEntry item)
    {
        if (item.Item is GlobalItem glItem)
        {
            if (!glItem.CanUse)
                return;

            if (!glItem.TryUse())
            {
                Debug.Log("Dupapaaa");
                sanityController.ItemUseFailed();
            }
        }
        else if (item.Item is Note note)
        {
            Debug.Log("Dziala?");
            DisplayNote(note);
        }
        else if (!(currentTargetObject?.TryUseItem(item.Item) ?? false))
        {
            sanityController.ItemUseFailed();
        }
    }

    public bool FindItem(string name)
    {
        foreach (ItemData item in items)
        {
            if (item.ItemName == name)
            {
                return true;
            }
        }
        
        return false;
    }

    public void TestFunction()
    {
        Debug.Log("Test success");
    }
}
