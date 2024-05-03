using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_lightning_script : MonoBehaviour
{
    public Light playerLight;
    public GameObject photomaking;

    private void Start()
    {
        Invoke("lightOff", 1);
        photomaking.SetActive(false);
    }

    void Update()
    {
    }

    private void lightOn()
    {
        playerLight.enabled = true;
        Invoke("lightOff", Random.Range(2, 4));
    }

    private void lightOff()
    {
        playerLight.enabled = false;
        if (Random.Range(1, 4) < 3)
            Invoke("lightOn", Random.Range(2, 4));
        else
        {
            Sound();
        }
    }

    public AudioClip walk;
    

    private void Sound()
    {
        GetComponent<AudioSource>().PlayOneShot(walk, 0.7f);
        Invoke("EndGame", 8.3f);
    }

    private void EndGame()
    {
        Application.Quit();
    }
}
