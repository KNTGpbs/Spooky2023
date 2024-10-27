using UnityEngine;

public class Tutodoor: SpecialItemTarget
{
    public float AnimSpeed = 1.0f / 2.0f;

    private Collider2D? enteredCollision;
    private float openingAnimTime;
    private OpenState openState;
    private SpriteRenderer sprite;
    private AudioSource audioSource;

    private void Start()
    {
        this.sprite = GetComponent<SpriteRenderer>();
        this.audioSource = GetComponent<AudioSource>();
    }

    public override void Use(ItemData item)
    {
        if (openState == OpenState.Closed)
        {
            TriggerOpen();
            GameObject.Find("Player").GetComponent<PlayerMovement>().Inventory.RemoveItem(item);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enteredCollision)
        {
            if (openState == OpenState.Open)
            {
                TutorialController.EndTutorial();
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

    private void TriggerOpen()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().Play("DoorOpen");
        audioSource.Play();
        openState = OpenState.Opening;
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