using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public bool start = false;
    public AnimationCurve curve;
    public float duration;

    [SerializeField] PlayerMovement PlayerScript;

    void Start()
    {
        
    }

    void Update()
    {
        if (start)
        {
            start = false;
            PlayerScript.IsCameraOn = true;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            PlayerScript.IsCameraOn = true;
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strenght;
            yield return null;
        }

        transform.position = startPosition;
        PlayerScript.IsCameraOn = false;
    }
}
