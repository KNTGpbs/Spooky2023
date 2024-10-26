using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.Events;

public class DoorOpen : MonoBehaviour
{
    private SpriteRenderer sprite;
    private bool enteredCollision = false;
    private bool isOpened = false;
    public UnityEvent openEvent;
    public UnityEvent<DoorOpen> enterEvent;
    //[SerializeField] private ItemData testItem;
    [SerializeField] private InventorySystem inventorySystem;
    void Start()
    {
        if (openEvent == null)
        {
            openEvent = new UnityEvent();
        }
        this.sprite = GetComponent<SpriteRenderer>();
        inventorySystem.AddItem(new ItemData("Key", GameObject.Find("FurnitureTest").GetComponent<FurnitureLogic>(), openEvent));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOpened == true && enteredCollision == true)
        {
            enterEvent.Invoke(this);
        }
        if (Input.GetKeyDown(KeyCode.Space) && enteredCollision == true && isOpened == false)
        {
            openEvent.Invoke(); 
            isOpened = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enteredCollision = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enteredCollision = false;
    }
}
