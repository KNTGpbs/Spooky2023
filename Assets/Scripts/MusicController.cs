using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource[] audioSource;

    public AudioClip[] audioClip;
    void Start()
    {
        audioSource = GetComponents<AudioSource>();
        audioSource[0].Play();
    }
    void Update()
    {
        if (!audioSource[0].isPlaying)
        {
            StartCoroutine(WaitAndExecute());
        }
        if (!audioSource[1].isPlaying)
        { 
            audioSource[1].Play();
        }
    }

    private IEnumerator WaitAndExecute()
    {
        yield return new WaitForSeconds(300);

        audioSource[0].Play();
    }

    public void OnSanity7()
    {
        audioSource[1].resource = audioClip[0];
        audioSource[1].Play();
    }
    public void OnSanity5()
    {
        audioSource[0].resource = audioClip[1];
        audioSource[0].Play();
    }
    public void OnSanity2()
    {
        audioSource[0].resource = audioClip[2];
        audioSource[0].Play();
    }
}
