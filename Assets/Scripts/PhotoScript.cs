using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoScript : MonoBehaviour
{
    [SerializeField] GameObject CameraLamp;
    [SerializeField] GameObject PlayerObject;
    [SerializeField] GameObject CameraUI;
    PlayerMovement playerScript;

    [SerializeReference] Camera OverlapingCamera;

    void Start()
    {
        playerScript = PlayerObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            OverlapingCamera.enabled = false;
            CameraLamp.SetActive(true);
            CameraUI.SetActive(true);
            playerScript.IsCameraOn = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            OverlapingCamera.enabled = true;
            CameraLamp.SetActive(false);
            CameraUI.SetActive(false);
            playerScript.IsCameraOn = false;
        }
    }
}
