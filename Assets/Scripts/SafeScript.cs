using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SafeScript : MonoBehaviour
{
    public Image[] stars;
    private String code = "1072";
    private String input = "";

    private void Start()
    {
        foreach (Image star in stars)
            star.enabled = false;
        
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
            //TODO: return szyfr
            //TODO: deactivate canvas
        }
        else{
            input = "";
            foreach (Image star in stars)
                star.enabled = false;
            GameObject.Find("Player").GetComponent<SanityController>().ModifySanity(-100f);
        }
    }
}