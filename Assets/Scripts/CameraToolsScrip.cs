using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToolsScrip : MonoBehaviour
{
    private PlayerCam PlayerScript;

    void Start()
    {
        PlayerScript = GameObject.Find("PlayerCam").GetComponent<PlayerCam>();
        StartCoroutine(Rotate(new Vector3(0, 360, 0), 1));
    }

    void Update()
    {
        if (!rotating)
            StartCoroutine(Rotate(new Vector3(0, 120, 0), 1));
    }

    private bool rotating = false;
    private IEnumerator Rotate(Vector3 angles, float duration)
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

    private void OnTriggerEnter(Collider other)
    {
        PlayerScript.CameraTollNum++;
        this.gameObject.SetActive(false);
    }
}
