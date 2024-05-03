using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterChaseScript : MonoBehaviour
{
    [SerializeField] GameObject Door;

    [SerializeField] AudioSource Audio;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            Door.SetActive(true);
            Audio.Play();

            Enemy1.SetActive(false);
            Enemy2.SetActive(false);
            Enemy3.SetActive(false);

            this.gameObject.GetComponent<End_lightning_script>().enabled = true;

            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
