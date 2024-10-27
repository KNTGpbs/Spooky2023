using System;
using UnityEngine;

public class WarningHide : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
        }
    }
}
