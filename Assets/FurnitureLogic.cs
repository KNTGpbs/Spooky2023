using UnityEngine;

public class FurnitureLogic : MonoBehaviour
{
    private bool playerEntered = false;

    public bool GetFlag()
    {
        return playerEntered;
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
