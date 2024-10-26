using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEditor.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private float input;
    private Rigidbody2D rb;
    private bool turnedToBG = false;
    [SerializeField] private GameObject inventoryCanvas;
    [SerializeField] private GameObject guiCanvas;
    public InventorySystem Inventory;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.W))
        {
            turnedToBG = true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryCanvas.SetActive(!inventoryCanvas.active);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            guiCanvas.SetActive(!guiCanvas.active);
        }

        List<Collider2D> colliders = new();
        rb.Overlap(colliders);
        ItemTarget target = null;
        foreach (var col in colliders)
        {
            target = col.GetComponent<ItemTarget>();
            if (target != null)
            {
                break;
            }
        }
        Inventory.currentTargetObject = target;
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = input * moveSpeed;
    }

    public bool GetTurnedToBG()
    {
        return turnedToBG;
    }
}
