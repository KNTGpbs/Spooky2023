using System;
using Unity.VisualScripting;
using UnityEngine;

public class DuckLogic : MonoBehaviour
{
    private bool isEntered = false;
    [SerializeField] private bool isRight = false;
    private ItemContainer container;
    [SerializeField] private SanityController sanityController;
    [SerializeField] private PlayerMovement playerMovement;
    void Start()
    {
        container = gameObject.GetComponent<ItemContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEntered && playerMovement.GetTurnedToBG())
        {
            if (isRight)
            {
                container.AddEachItem();
                gameObject.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                sanityController.ModifySanity(-5000);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isEntered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isEntered = false;
    }
}
