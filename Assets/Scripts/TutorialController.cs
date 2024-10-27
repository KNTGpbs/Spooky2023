using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialController: MonoBehaviour
{
    private float animationProgress = 0.0f;
    private RawImage bg;
    private Canvas canvas;
    [SerializeField] private string mainScene;

    private void Start()
    {
        enabled = false;
        canvas = GetComponent<Canvas>();
        bg = GetComponentInChildren<RawImage>();
        canvas.enabled = false;
    }

    private void Update()
    {
        animationProgress += Time.deltaTime;
        bg.color = bg.color.WithAlpha(Math.Min(1.0f, animationProgress / 1.5f));
        if (animationProgress >= 2.0f)
        {
            SceneManager.LoadSceneAsync(mainScene);
        }
    }

    public static void EndTutorial() {
        var cont = FindFirstObjectByType<TutorialController>();
        cont.enabled = true;
        cont.canvas.enabled = true;
    }
}