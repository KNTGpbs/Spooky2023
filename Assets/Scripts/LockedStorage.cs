using UnityEngine;

public class LockedStorage: SpecialItemTarget
{
    //public AudioClip? UnlockSound;
    private ItemContainer container;

    private void Start()
    {
        container = GetComponent<ItemContainer>();
        container.IsLocked = true;
    }

    public override void Use(ItemData item)
    {
        container.IsLocked = false;
        //if (UnlockSound)
        //{
        //    // TODO: Play sound
        //}
        Debug.Log($"Item {item.ItemName} is used");
        container.AddEachItem();
    }
}