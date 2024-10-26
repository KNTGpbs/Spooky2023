using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    private bool playerEntered = false;
    private bool used = false;
    public InventorySystem inventorySystem;
    private PlayerMovement player;
    //[SerializeField] private GameObject furniture;

    public string[] Items;

    public bool IsLocked = false;

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

        if (Input.GetKeyDown(KeyCode.H) && !IsLocked && player.GetTurnedToBG() && !used)
        {
            /*
            Debug.Log(GameObject.Find("FurnitureTest").GetComponent<ItemContainer>().GetFlag());
            GameObject furniture = GameObject.Find("FurnitureTest");
            //ItemData item = new ItemData("Key", furniture, penEvent);
            ItemData item = new SpecialItem("Key", furniture);
            inventorySystem.AddItem(item);
            */
            AddEachItem();
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
        this.SetUsed();
    }
}
