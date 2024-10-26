using UnityEngine;
using UnityEngine.Events;

public interface ItemTarget
{
    public bool TryUseItem(ItemData item);
}

public abstract class SpecialItemTarget : MonoBehaviour, ItemTarget
{
    public string TargetId;

    public bool TryUseItem(ItemData item)
    {
        if (!(item is SpecialItem specialItem))
            return false;

        if (specialItem.Target != this.TargetId)
            return false;

        Use(item);
        return true;
    }

    public abstract void Use(ItemData item);
}