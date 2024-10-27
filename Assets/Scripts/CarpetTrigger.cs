using UnityEngine;

public class CarpetTrigger : MonoBehaviour
{
    private ItemContainer itemContainer;

    private PlayerMovement player;
    private SpriteRenderer sr;

    [SerializeField] private Sprite usedCarpet;

    [SerializeField] private GameObject plank;
    private bool playerEntered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        itemContainer = gameObject.GetComponent<ItemContainer>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        plank = GameObject.Find("deska");
        plank.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !itemContainer.IsLocked && player.GetTurnedToBG() && !itemContainer.GetUsed() && playerEntered)
        {
            plank.SetActive(true);
            itemContainer.AddEachItem();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerEntered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerEntered = false;
    }
}