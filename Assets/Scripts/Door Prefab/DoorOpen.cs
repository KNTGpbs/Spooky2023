using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.Events;

public class DoorOpen : MonoBehaviour
{
    private SpriteRenderer sprite;
    private bool enteredCollision = false;
    private bool isOpened = false;
    public UnityEvent openEvent;
    public UnityEvent<DoorOpen> enterEvent;
    void Start()
    {
        if (openEvent == null)
        {
            openEvent = new UnityEvent();
        }
        this.sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enteredCollision)
        {
            if (isOpened)
            {
                enterEvent.Invoke(this);
            }
            else
            {
                openEvent.Invoke();
                isOpened = true;
                // TODO(@ktoś): ustaw sprite
                var color = sprite.color;
                color.a = 0.2f;
                sprite.color = color;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enteredCollision = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enteredCollision = false;
    }
}
