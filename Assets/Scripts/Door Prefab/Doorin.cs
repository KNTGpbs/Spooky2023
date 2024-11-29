using UnityEngine;
using UnityEngine.Events;

enum OpenState
{
    Closed,
    Opening,
    Open,
}

public class Doorin : MonoBehaviour
{
    public UnityEvent doorOpened;
    
    public Doorin OtherDoor;
    public float AnimSpeed = 1.0f / 2.0f;
    
    private Collider2D? enteredCollision;
    private float openingAnimTime;
    private OpenState openState;
    private SpriteRenderer sprite;

    private void Start()
    {
        this.sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enteredCollision)
        {
            if (openState == OpenState.Closed)
            {
                TriggerOpen(this);
                doorOpened.Invoke();
            }
            else if (openState == OpenState.Open)
            {
                enteredCollision.transform.position += OtherDoor.transform.position - transform.position;
            }
        }

        if (openState == OpenState.Opening)
        {
            openingAnimTime += AnimSpeed * Time.deltaTime;
            
            if (openingAnimTime >= 1.0f)
            {
                openState = OpenState.Open;
            }
        }
    }

    private static void TriggerOpen(Doorin door)
    {
        do
        {
            door.GetComponent<Animator>().enabled = true;
            door.GetComponent<Animator>().Play("DoorOpen");
            door.openState = OpenState.Opening;
            door = door.OtherDoor;
        } while (door?.openState == OpenState.Closed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enteredCollision = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == enteredCollision)
            enteredCollision = null;
    }
}