using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private GameObject listener;
    
    [SerializeField] private List<AudioSource> audioSources;
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private List<Collider2D> colliders;
    
    private const float MUSIC_VOLUME = 1f;
    private const float WHISPER_VOLUME = 1f;
    private const float AUTODUCK_VOLUME = .2f;
    private const float AUTODUCK_FADE_DURATION = 1f;
    
    bool lastAutoduckState = false;
    
    //Audio
    //0-2 Muzyka
    //3-4 Szepty
    //5 Krzyk
    //6 Don't go in
    
    //Source
    //0 Muzyka
    //1 Szepty
    //2 Złe użycie
    //3 Drzwi do darkroomu
    
    //Collider2D
    //0 Darkroom
    
    public void Start()
    {
        StartCoroutine(ChangeMusic(audioClips[0], audioSources[0], 1));
        audioSources[0].loop = true;
        StartCoroutine(ChangeMusic(audioClips[3], audioSources[1], 1));
        audioSources[1].loop = true;
    }

    private void Update()
    {
        bool autoduckState = false;
        for (var i = 3; i < audioSources.Count; i++)
        {
            if (audioSources[i].isPlaying && Vector3.Distance(listener.transform.position, audioSources[i].gameObject.transform.position) < audioSources[i].maxDistance)
            {
                autoduckState = true;
            }
        }

        if (autoduckState != lastAutoduckState)
        {
            if (!autoduckState) AutoDuck(false);
            else AutoDuck(true);
            lastAutoduckState = autoduckState;
        }
    }

    public void OnAudioTriggerEnter(Collider2D collision)
    {
        
    }

    public void OnAudioTriggerExit(Collider2D collision)
    {
        
    }

    public void On7Sanity()
    {
        StartCoroutine(ChangeMusic(audioClips[1], audioSources[0], 2));
    }

    public void On5Sanity()
    {
        StartCoroutine(ChangeMusic(audioClips[4], audioSources[1], 2));
    }
    
    public void On2Sanity()
    {
        StartCoroutine(ChangeMusic(audioClips[2], audioSources[0], 2));
    }

    public void OnBadUse()
    {
        AutoDuck(true);
        StartCoroutine(ChangeMusic(audioClips[5], audioSources[2], 2));
    }

    public void OnDarkRoomDoorOpen()
    {
        StartCoroutine(ChangeMusic(audioClips[6], audioSources[3], 2));
        audioSources[3].loop = true;
    }
    private IEnumerator ChangeMusic(AudioClip newClip, AudioSource source, float fadeDuration)
    {
        float currentTime = 0f;
        float startVolume = source.volume;

        if (source.isPlaying)
        {
            while (currentTime < fadeDuration)
            {
                currentTime += Time.deltaTime;
                source.volume = Mathf.Lerp(startVolume, 0, currentTime / fadeDuration);
                yield return null;
            }

            source.Stop();
        }
        source.clip = newClip;
        source.Play();
        
        currentTime = 0f;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(0, 1, currentTime / fadeDuration);
            yield return null;
        }
    }
    private IEnumerator VolumeChange(AudioSource source, float fadeDuration, float targetVolume)
    {
        float currentTime = 0f;
        float startVolume = source.volume;

        if (source.isPlaying)
        {
            while (currentTime < fadeDuration)
            {
                currentTime += Time.deltaTime;
                source.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / fadeDuration);
                yield return null;
            }
        }
    }
    private void AutoDuck(bool isOn)
    {
        if (isOn)
        {
            StartCoroutine(VolumeChange(audioSources[0], AUTODUCK_FADE_DURATION, AUTODUCK_VOLUME));
            StartCoroutine(VolumeChange(audioSources[1], AUTODUCK_FADE_DURATION, AUTODUCK_VOLUME));
        }
        else
        {
            StartCoroutine(VolumeChange(audioSources[0], AUTODUCK_FADE_DURATION, MUSIC_VOLUME));
            StartCoroutine(VolumeChange(audioSources[1], AUTODUCK_FADE_DURATION, WHISPER_VOLUME));
        }
    }
    
}
