using UnityEngine;
using UnityEngine.UI;

public class NoteContainer : MonoBehaviour
{
    private bool isEntered = false;
    [SerializeField] private GameObject noteDisplayer;
    [SerializeField] private Sprite note;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEntered)
        {
            noteDisplayer.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isEntered = true;
        noteDisplayer.GetComponent<Image>().sprite = note;
        noteDisplayer.transform.parent.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isEntered = false;
        noteDisplayer.SetActive(false);
        noteDisplayer.transform.parent.gameObject.SetActive(false);
    }
}
