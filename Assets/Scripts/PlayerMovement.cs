using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private float input;
    private Rigidbody2D rb;
    private bool turnedToBG = false;
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
