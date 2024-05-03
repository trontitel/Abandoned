using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonJumpscareScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                GetComponent<Animator>().SetBool("JumpScare", true);
                GetComponent<AudioSource>().Play();
                Invoke("SceletonDestroy", 1f);
            }
        }
    }

    private void SceletonDestroy()
    {
        Destroy(this.gameObject);
    }
}

