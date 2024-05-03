using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        light1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Light light1;
    public void LightOn()
    {
        light1.enabled = true;
    }
    public void LightOff()
    {
        light1.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Hover()
    {
        light1.enabled = true;
    }

    public void notHover()
    {
        light1.enabled = false;

    }
}
