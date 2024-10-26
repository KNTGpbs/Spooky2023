using UnityEngine;

enum OpenState
{
    Closed,
    Opening,
    Open,
}

public class Doorin : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Space) && enteredCollision)
        {
            if (openState == OpenState.Closed)
            {
                TriggerOpen();
            }
            else if (openState == OpenState.Open)
            {
                enteredCollision.transform.position += OtherDoor.transform.position - transform.position;
            }
        }

        if (openState == OpenState.Opening)
        {
            openingAnimTime += AnimSpeed * Time.deltaTime;
            // TODO: Wstaw dobrą animację
            var color = sprite.color;
            color.r = 1.0f - openingAnimTime;
            color.g = 1.0f - openingAnimTime;
            sprite.color = color;
            if (openingAnimTime >= 1.0f)
            {
                openState = OpenState.Open;
            }
        }
    }

    private void TriggerOpen()
    {
        Doorin? door = this;
        do
        {
            // TODO: Odtwórz dźwięk drzwi
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