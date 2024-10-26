using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_NoteDisplay : MonoBehaviour
{
    private Image note;
    void Start()
    {
        note = GetComponent<Image>();
        note.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && note.gameObject.activeInHierarchy)
        {
            note.gameObject.SetActive(false);
        }
    }

    public void ChangeNote(Sprite noteSprite)
    {
        note.sprite = noteSprite; 
        note.gameObject.SetActive(true);
    }
}
