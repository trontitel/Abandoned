using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointManager checkpointManagerScript;
    [SerializeField] PlayerCam PlayerScript;
    
    void Start()
    {   
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            checkpointManagerScript.ActiveCheckpoint = this.gameObject.transform;
            checkpointManagerScript.photoNumber = PlayerScript.CameraTollNum;

            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
