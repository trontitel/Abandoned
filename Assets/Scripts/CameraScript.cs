using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] GameObject CameraObject;
    [SerializeField] GameObject Hint;

    void Start()
    {
        
    }

    bool inRange = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            CameraObject.SetActive(true);
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Hint.SetActive(true);
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Hint.SetActive(false);
        inRange = false;
    }
}
