using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEvent : MonoBehaviour
{
    [SerializeField] CameraShake camShake;
    public  GameObject Enemy1;
    public  GameObject Enemy2;
    public  GameObject Enemy3;

    [SerializeField] GameObject Door;

    [SerializeField] AudioSource Audio;

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
            Door.SetActive(true);
            camShake.start = true;
            Audio.Play();
            Invoke("SpawnEnemies", 3);
        }
    }

    private void SpawnEnemies()
    {
        Enemy1.SetActive(true);
        Enemy2.SetActive(true);
        Enemy3.SetActive(true);
    }
}
