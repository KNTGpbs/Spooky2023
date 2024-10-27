using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FirstAidKitLogic : MonoBehaviour
{
    [SerializeField] private GameObject anchorListObject;
    [SerializeField] private GameObject useItem;
    [SerializeField] private GameObject inventoryPremadeGui;
    private bool isEntered = false;
    private ItemContainer container;
    public string[] items;

    private void Start()
    {
        container = GetComponent<ItemContainer>();
        items = container.Items;
        int count = 0;
        foreach (Transform child in anchorListObject.transform)
        {
            float los = Random.Range(count, items.Length);
            var addedItem = Instantiate(useItem);
            addedItem.transform.SetParent(child.transform, false);
            addedItem.transform.position = child.transform.position;
            addedItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = items[Mathf.RoundToInt(los)];
            count++;
        }
        inventoryPremadeGui.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEntered)
        {
            inventoryPremadeGui.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isEntered = true;
        inventoryPremadeGui.transform.parent.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isEntered = false;
        inventoryPremadeGui.SetActive(false);
        inventoryPremadeGui.transform.parent.gameObject.SetActive(true);
    }
}
