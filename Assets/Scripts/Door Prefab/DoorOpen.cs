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
        if (Input.GetKeyDown(KeyCode.Space) && isOpened == true && enteredCollision == true)
        {
            enterEvent.Invoke(this);
        }
        if (Input.GetKeyDown(KeyCode.Space) && enteredCollision == true && isOpened == false)
        {
            openEvent.Invoke();
            isOpened = true;
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
