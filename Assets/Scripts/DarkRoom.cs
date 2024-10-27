using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DarkRoom : MonoBehaviour
{
    [SerializeField] public bool isCandleUsed = false;
    Light2D playerLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && !collision.gameObject.CompareTag("Player"))
        {
            if (!isCandleUsed)
            {
                playerLight = GameObject.Find("PlayerLight").GetComponent<Light2D>();
                playerLight.enabled = false;
            }
            playerLight.color = new Color(1, .40f, .10f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && !collision.gameObject.CompareTag("Player"))
        {
            if (!isCandleUsed)
            {
                playerLight.enabled = true;
                playerLight.color = Color.white;
            }
        }
    }

    public void ChangeIsCandleUsed()
    {
        isCandleUsed = true;
        playerLight.enabled = true;
        playerLight.color = new Color(1, .40f, .10f);
    }
}
