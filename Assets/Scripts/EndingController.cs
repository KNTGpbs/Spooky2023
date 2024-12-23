﻿using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Ending
{
    ExitDoor,
    Phone,
    BadPills,
    GoodPills,
    SanityOver
}

public class EndingController: MonoBehaviour
{
    public GameObject GameContainer;
    private RawImage background;
    private TextMeshProUGUI text;
    private float animationProgess = 0.0f;

    private void Start()
    {
        enabled = false;
        background = GetComponentInChildren<RawImage>() ?? throw new NullReferenceException("Background not found");
        text = GetComponentInChildren<TextMeshProUGUI>() ?? throw new NullReferenceException("Text not found");
    }

    private void Update()
    {
        animationProgess += Time.deltaTime;
        background.color = background.color.WithAlpha(Math.Min(1.0f, animationProgess / 2.0f));
        text.color = text.color.WithAlpha(Math.Clamp((animationProgess - 1.0f) / 3.0f, 0.0f, 1.0f));
        if (animationProgess >= 4.0f)
        {
            enabled = false;
        }
    }

    public static EndingController FindInstance()
    {
        return FindFirstObjectByType<EndingController>();
    }
    
    public void Reset()
    {
        animationProgess = 0.0f;
        background.color = background.color.WithAlpha(0.0f);
        text.color = text.color.WithAlpha(0.0f);
    }

    public void TriggerEnding(Ending ending)
    {
        GameContainer.SetActive(false);
        background.color = background.color.WithAlpha(0.0f);
        text.color = text.color.WithAlpha(0.0f);
        text.fontSize = 64f;
        text.text = ending switch
        {
            Ending.ExitDoor => 
            @"You've managed to escape this haunted house, but nothing seems like it used to.
            It seems that everyone and everything is against you. Those faces and voices are everywhere
            and no one can be trusted. YOU ARE ALONE AND ALWAYS WILL BE. But you will never come back to this house.
            You ran away successfully.
                Ending #1 of 5",
            Ending.Phone =>
            @"You called your mother using the phone in your living room.
            Even though, she had to stay in the hospital for a few more days, she immediately called for help.
            You are now hospitalised again, and thanks to the new medication, and therapy you are slowly getting better.
            You still feel alone, but you know you will manage with the support of your family. 
            You Just have to take care of yourself and give yourself some time.
                Ending #2 of 5",
            Ending.BadPills => 
            @"The last sound you've heard was sirens coming closer towards you.
            The scariest part was, YOU WERE ALL ALONE.
                Ending #3 of 5",
            Ending.SanityOver =>
            @"YOU WISHED YOU WERE ALONE. 
                Ending #4 of 5",
            Ending.GoodPills =>
            @"After taking your medication, the voices had stopped. You finally felt at peace.
            You finally were alone. You just wished someone could share your happiness.
                Ending #5 of 5",
            _ => throw new ArgumentOutOfRangeException(nameof(ending), "burg"),
        };
        enabled = true;
    }

    public void TriggerBadEnding()
    {
        TriggerEnding(Ending.SanityOver);
    }
}