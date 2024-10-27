using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FirstAidKitLogic : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPremadeGui;
    [SerializeField] private SanityController sanityController;
    [SerializeField] private EndingController endingController;
    [SerializeField] private InventorySystem inventorySystem;
    //[SerializeField] private GameObject bathroomFloorManager;
    private bool isEntered = false;
    private ItemContainer container;

    private void Start()
    {
        container = GetComponent<ItemContainer>();
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
    
    public void BadClick_Action()
    {
        if (inventorySystem.FindItem("Encrypted Message"))
        {
            endingController.TriggerEnding(Ending.BadPills);
        }
    }

    public void GoodClick_Action()
    {
        if (inventorySystem.FindItem("Encrypted Message"))
        {
            endingController.TriggerEnding(Ending.BadPills);
            if (inventorySystem.FindItem("Diagnose"))
            {
                
                endingController.TriggerEnding(Ending.GoodPills);
            }
        }
    }

    public void SanityClick_Action()
    {
        if (inventorySystem.FindItem("Encrypted Message"))
        {
            sanityController.ModifySanity(-2000);
        }
    }
}
