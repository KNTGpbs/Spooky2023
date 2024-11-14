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
    [SerializeField] private GameObject noteDisplayer;
    public InventorySystem Inventory;
    
    private Animator animator;
    
    private String walkAnim = "Player_walk";
    private String idleAnim = "Player_idle";
    private String backAnim = "Player_up";
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        input = Input.GetAxis("Horizontal");
        if (input != 0)
        {
            animator.Play(walkAnim);
            if(!Input.GetKey(KeyCode.LeftShift))GetComponent<SpriteRenderer>().flipX = input < 0;
            turnedToBG = false;
        }
        else if(!turnedToBG)
        {
            animator.Play(idleAnim);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            turnedToBG = true;
            animator.Play(backAnim);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Inventory.Toggle();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            noteDisplayer.SetActive(false);
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
