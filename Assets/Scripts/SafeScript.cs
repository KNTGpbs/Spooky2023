using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SafeScript : MonoBehaviour
{
    public Image[] stars;
    [SerializeField] String code = "1072";
    private String input = "";
    private ItemContainer container;
    [SerializeField] private GameObject safeGui;
    private bool isEntered = false;
    private bool used = false;
    private PlayerMovement player;

    public bool GetUsed()
    {
        return used;
    }
    public void SetUsed()
    {
        if (!used) used = true;
    }

    private void Start()
    {
        foreach (Image star in stars)
            star.enabled = false;
        container = GetComponent<ItemContainer>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isEntered && !container.GetUsed() && player.GetTurnedToBG())
        {
            safeGui.SetActive(true);
        }
    }

    public void AddCodeNumber(int number)
    {
        stars[input.Length].enabled = true;
        input += (number.ToString());
        if(input.Length == code.Length)
            CheckPin(input);
    }

    private void CheckPin(String pin)
    {
        if (pin == code){
            safeGui.SetActive(false);
            if(gameObject.name == "Phone")
                EndingController.FindInstance().TriggerEnding(Ending.Phone);
            else
                container.AddEachItem();
        }
        else{
            input = "";
            foreach (Image star in stars)
                star.enabled = false;
            GameObject.Find("Player").GetComponent<SanityController>().ModifySanity(-100f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isEntered = true;
        safeGui.transform.parent.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isEntered = false;
        safeGui.SetActive(false);
        safeGui.transform.parent.gameObject.SetActive(false);
    }
}