using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    private bool playerEntered = false;
    private bool used = false;
    public InventorySystem inventorySystem;
    private PlayerMovement player;
    //[SerializeField] private GameObject furniture;

    public List<String> Items;

    public bool IsLocked = false;

    private void Awake()
    {
        gameObject.AddComponent<InteractableHighlights>();
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        inventorySystem = player.Inventory;
    }
    public bool GetUsed()
    {
        return used;
    }
    public void SetUsed()
    {
        if(!used) used = true;
    }
    public bool GetFlag()
    {
        return playerEntered;
    }

    private void Update()
    {
        if (!playerEntered)
            return;
        
        if (Input.GetKeyDown(KeyCode.E) && player.GetTurnedToBG())
        {
            if (IsLocked && Items.Count != 0)
            {
                UIMessage.Instance.ShowMessage("You can`t even use it without...");
            }
            else if (used)
            {
                UIMessage.Instance.ShowMessage(("It is empty like you!"));
            }
            /*
            Debug.Log(GameObject.Find("FurnitureTest").GetComponent<ItemContainer>().GetFlag());
            GameObject furniture = GameObject.Find("FurnitureTest");
            //ItemData item = new ItemData("Key", furniture, penEvent);
            ItemData item = new SpecialItem("Key", furniture);
            inventorySystem.AddItem(item);
            */
            else if(Items.Count!=0) AddEachItem();
        }
    }

   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerEntered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerEntered = false;
    }

    public void AddEachItem()
    {
        foreach (var itemId in Items)
        {
            var item = ItemTable.GetItem(itemId);
            Debug.Log($"Item received: {item.ItemName}");
            inventorySystem.AddItem(item);
        }
        UIMessage.Instance.ShowMessage("You found something");
        GetComponent<ParticleSpawner>().PlayParticles();
        this.SetUsed();
        var interactable = gameObject.GetComponent<InteractableHighlights>();
        interactable.used = false;
        interactable.Highlight(false);
    }
}
