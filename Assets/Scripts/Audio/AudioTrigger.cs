using System;
using UnityEngine;
using UnityEngine.Events;

public class AudioTrigger : MonoBehaviour
{
    public UnityEvent<Collider2D> audioTriggerEnter;
    public UnityEvent<Collider2D> audioTriggerExit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        audioTriggerEnter?.Invoke(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        audioTriggerExit?.Invoke(other);
    }
}
