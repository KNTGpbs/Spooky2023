using UnityEngine;
using UnityEngine.Events;

public class DarkRoomTarget : SpecialItemTarget
{

    public UnityEvent candleUsed, darkEntered, darkExited;
    //public AudioClip? UnlockSound;
    private ItemContainer container;
    private bool isCandleUsed = false;

    private void Start()
    {
        container = GetComponent<ItemContainer>();
    }

    public override void Use(ItemData item)
    {
        GetComponent<DarkRoom>().ChangeIsCandleUsed();
        isCandleUsed = true;
        candleUsed.Invoke();
        container.inventorySystem.RemoveItem(item);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Player") && isCandleUsed)
        {
            darkEntered.Invoke();
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") && isCandleUsed)
        {
            darkExited.Invoke();
            Debug.Log("Exited");
        }
    }
}