using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class UI_NoteDisplay : MonoBehaviour
{
    [SerializeField] private Image note;
    [SerializeField] private GameObject guiCanvas;

    public void ChangeNote(String noteSprite)
    {
        note.sprite = Resources.Load<Sprite>(noteSprite);
        note.gameObject.SetActive(true); 
    }  
}
