using System.Collections.Generic;
using System.Linq;

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
        new("łom", new SpecialItem("Łom", "plank")),
        new("exit-key", new SpecialItem("Klucz", "exit")),
        new("sun", new SpecialItem("Świeczka", "dark")),
        new("szyfr", new SpecialItem("Alf. szyfr", ""))
    });

    public static readonly UseEntry[] UseTable = new[] {
        new UseEntry { ObjectId = "deska", ItemId = "łom" },
        new UseEntry { ObjectId = "exit", ItemId = "exit-key" },
    };

    public static ItemData GetItem(string id)
    {
        var item = KnownItems[id]
            ?? throw new System.Exception("Unknown item");

        return item;
    }
}