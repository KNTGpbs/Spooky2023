using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public static class ItemTable {
    public record Item
    {
        public readonly string id;
        public readonly string Name;
        // TODO: Sprite path

        public Item(string id, string name)
        {
            this.id = id;
            this.Name = name;
        }
    }

    public struct UseEntry {
        public string ObjectId;
        public string ItemId;
    }

    public static readonly Dictionary<string, ItemData> KnownItems = new(new KeyValuePair<string, ItemData>[]
    {
        new("crowbar", new SpecialItem("Crowbar", "plank")),
        new("exit-key", new SpecialItem("Key", "exit")),
        new("sun", new SpecialItem("Candle", "DarkRoom")),
        new("szyfr", new SpecialItem("Cipher Alphabet", "")),
        new("tel", new SpecialItem("Phone Number", "")),
    });
    
    public static readonly UseEntry[] UseTable = new[] {
        new UseEntry { ObjectId = "deska", ItemId = "crowbar" },
        new UseEntry { ObjectId = "exit", ItemId = "exit-key" },
    };

    public static ItemData GetItem(string id)
    {
        var item = KnownItems[id]
            ?? throw new System.Exception("Unknown item");

        return item;
    }
}