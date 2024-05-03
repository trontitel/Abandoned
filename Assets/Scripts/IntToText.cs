using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntToText : MonoBehaviour
{
    [SerializeField] PlayerCam PlayerScript;

    public Text ValueText;

    // Update is called once per frame
    void Update()
    {
        ValueText.text = PlayerScript.CameraTollNum.ToString();
    }
}
