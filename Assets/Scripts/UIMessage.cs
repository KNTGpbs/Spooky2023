using System.Collections;
using TMPro;
using UnityEngine;

public class UIMessage : MonoBehaviour
{
    public static UIMessage Instance;

    public TMP_Text messageText;
    public float displayTime = 5f;

    private Coroutine currentRoutine;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void ShowMessage(string text)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        messageText.text = text;
        gameObject.SetActive(true);

        currentRoutine = StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
        currentRoutine = null;
    }
}
