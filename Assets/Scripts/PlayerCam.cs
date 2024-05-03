using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    //public GameObject PlayerObj;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public float radius;
    public LayerMask layerMask;

    public int CameraTollNum;
    [SerializeField] GameObject FlashLight;
    public AudioSource FlashAudio;

    public LayerMask layer;

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        //PlayerObj.transform.rotation = Quaternion.Euler(0,0,yRotation);

        bool raycast = Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, layerMask);
        bool spherecast1 = Physics.SphereCast(transform.position, radius, transform.forward, out var hit2, Mathf.Infinity, layerMask);
        bool spherecast2 = Physics.SphereCast(transform.position, radius * 2, transform.forward, out var hit3, Mathf.Infinity, layerMask);

        if (GameObject.Find("CameraUI") && CameraTollNum > 0)
        {
            if (spherecast1)
            {
                Debug.DrawRay(transform.position, hit2.collider.transform.position - transform.position);
                if (Physics.Raycast(transform.position, hit2.collider.transform.position - transform.position, out var hit0, Mathf.Infinity, layer, QueryTriggerInteraction.Ignore))
                {
                    //Debug.Log(hit0.collider.gameObject.name);
                    if (hit0.collider.gameObject.tag == "Enemy")
                    {
                        //Debug.Log("see");
                        if (Input.GetKey(KeyCode.Mouse0))
                        {
                            //Debug.Log("Destroy");
                            GameObject pom = hit0.collider.gameObject.transform.parent.gameObject;
                            pom.SetActive(false);
                        }
                    }
                }


            }
            if (spherecast2)
            {
                Debug.DrawRay(transform.position, hit3.collider.transform.position - transform.position);
                if (Physics.Raycast(transform.position, hit3.collider.transform.position - transform.position, out var hit0, Mathf.Infinity, layer, QueryTriggerInteraction.Ignore))
                {
                    if (hit0.collider.gameObject.tag == "Enemy")
                    {
                        //Debug.Log("see");
                        if (Input.GetKey(KeyCode.Mouse0))
                        {
                            GameObject pom = hit0.collider.gameObject.transform.parent.gameObject;
                            pom.SetActive(false);
                        }
                    }
                }


            }
            if (raycast)
            {
                Debug.DrawRay(transform.position, hit.collider.transform.position - transform.position);
                if (Physics.Raycast(transform.position, hit.collider.transform.position - transform.position, out var hit0, Mathf.Infinity, layer, QueryTriggerInteraction.Ignore))
                {
                    if (hit0.collider.gameObject.tag == "Enemy")
                    {
                        //Debug.Log("see");
                        if (Input.GetKey(KeyCode.Mouse0))
                        {
                            GameObject pom = hit0.collider.gameObject.transform.parent.gameObject;
                            pom.SetActive(false);
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                CameraTollNum--;
                FlashLight.SetActive(true);
                FlashAudio.Play();
                Invoke("FlashlightOn", 0.7f);

            }
        }


    }

    private void FlashlightOn()
    {
        FlashLight.SetActive(true);
        Invoke("FlashlightOff", 0.05f);
    }

    private void FlashlightOff()
    {
        FlashLight.SetActive(false);
    }
}

