using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Ending
{
    ExitDoor,
    Phone
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
        background.color = background.color.WithAlpha(Math.Max(1.0f, animationProgess / 2.0f));
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
            It seems that every one and everything is against you. Those faces and voices are everywhere
            and no one can be trusted. YOU ARE ALONE AND ALWAYS WILL BE. Bun you will never come back to this house.
            You ran away successfully.
                Ending #2 of 5",
            Ending.Phone =>
            @"You called your mother using the phone in your living room.
            Even though, she had to stay in the hospital for a few more days, she immediately called for help.
            You are now hospitalised again, and thanks to the new medication, and therapy you are slowly getting better.
            You still fill alone, but you know you will manage with the support of your family. 
            You Just have to take care of yourself and give yourself some time.
                Ending #1 of 5",
            _ => throw new ArgumentOutOfRangeException(nameof(ending), "burg"),
        };
        enabled = true;
    }
}