using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private Dictionary<String, AudioSource> audioSources;
    private Dictionary<String, AudioClip> audioClips;
    private Dictionary<String, Collider2D> colliders;
    private GameObject audioPlayerTrigger;

    public void OnAudioTriggerEnter(Collider2D collision)
    {
        
    }

    public void OnAudioTriggerExit(Collider2D collision)
    {
        
    }

}
