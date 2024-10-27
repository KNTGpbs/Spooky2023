using UnityEngine;

public class DarkRoomTarget : SpecialItemTarget
{
    //public AudioClip? UnlockSound;
    private ItemContainer container;

    private void Start()
    {
        container = GetComponent<ItemContainer>();
    }

    public override void Use(ItemData item)
    {
        GetComponent<DarkRoom>().ChangeIsCandleUsed();
        container.inventorySystem.RemoveItem(item);
    }
}