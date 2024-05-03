using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !rotating && !switchDown)
            {
                StartCoroutine(Rotate(new Vector3(0, 0, 80), 1));
                audio.Play();
                switchDown = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && !rotating && switchDown)
            {
                StartCoroutine(Rotate(new Vector3(0, 0, -80), 1));
                audio.Play();
                switchDown = false;
            }
        }
    }

    private bool rotating = false;
    public IEnumerator Rotate(Vector3 angles, float duration)
    {
        rotating = true;
        Quaternion startRotation = this.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            this.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        this.transform.rotation = endRotation;
        rotating = false;

    }

    bool PlayerInRange = false;
    public bool switchDown = false;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInRange = true;

    }
    private void OnTriggerExit(Collider other)
    {
        PlayerInRange = false;

    }

    public void Reset()
    {
        StartCoroutine(Rotate(new Vector3(0, 0, -80), 1));
        switchDown = false;
    }
}
