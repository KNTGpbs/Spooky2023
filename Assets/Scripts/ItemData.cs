using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Events;

//[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : MonoBehaviour
{
    public string itemName;
    [SerializeReference] private FurnitureLogic furniture;
    public UnityEvent itemEvent;

    public ItemData(string itemName, FurnitureLogic furniture, UnityEvent itemEvent)
    {
        this.itemName = itemName;
        this.furniture = furniture;
        this.itemEvent = itemEvent;
    }

    public void Use()
    {
        if (furniture.GetFlag())
        {
            if(GameObject.Find("Player").GetComponent<PlayerMovement>().GetTurnedToBG())
            {
                Debug.Log($"Item {itemName} is used");
                itemEvent.Invoke();
            }
        }
    }
}
