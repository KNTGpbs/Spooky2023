using System;
using UnityEngine;

public class InteractableHighlights : MonoBehaviour
{
    public bool used = false;             // Czy obiekt nadal można użyć
    [Header("Outline settings")]
    public Color outlineColor = Color.yellow;
    public float outlineThickness = 0.05f;    // im mniejsza wartość, tym subtelniejsze obramowanie

    private SpriteRenderer sr;
    private GameObject outlineObject;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        // Tworzymy outline jako dziecko obiektu
        outlineObject = new GameObject("Outline");
        outlineObject.transform.parent = transform;
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localRotation = Quaternion.identity;

        var outlineSR = outlineObject.AddComponent<SpriteRenderer>();
        outlineSR.sprite = sr.sprite;
        outlineSR.sortingLayerID = sr.sortingLayerID;
        outlineSR.sortingOrder = sr.sortingOrder - 1; // outline pod sprite'm
        outlineSR.color = outlineColor;

        // Minimalnie powiększamy aby uzyskać efekt obramowania
        outlineObject.transform.localScale = Vector3.one + Vector3.one * outlineThickness;

        outlineObject.SetActive(false);
    }
    public void Highlight(bool state)
    {
        if (used)
        {
            outlineObject.SetActive(false);
            return;
        }

        outlineObject.SetActive(state);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
            Highlight(true);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        Highlight(false);
    }
}
