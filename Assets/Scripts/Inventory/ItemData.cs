using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Events;

public abstract class ItemData
{
    // TODO: Change to sprite
    public string ItemName;
    //public GameObject furniture;
    //public UnityEvent itemEvent;
}

public class SpecialItem: ItemData
{
    //public readonly GameObject Target;
    public readonly string Target;

    public SpecialItem(string name, string target)
    {
        ItemName = name;
        Target = target;
    }
}

public abstract class GlobalItem: ItemData
{
    public abstract bool CanUse { get; }

    public abstract bool TryUse();
}

public class Note: ItemData
{
    public readonly string Sprite;

    public Note(string name, string sprite)
    {
        ItemName = name;
        Sprite = sprite;
    }
}