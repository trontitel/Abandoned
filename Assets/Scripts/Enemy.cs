using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject wayPoint;

    private Vector3 wayPointPos;
    [SerializeField] Transform playerObj;

    //This will be the zombie's speed. Adjust as necessary.
    public float speed;

    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("WayPoint");

        audioSource = GetComponent<AudioSource>();
    }
    
    public bool EnemyFollowThePlayer = false;
    AudioSource audioSource;

    void Update()
    {
        if (EnemyFollowThePlayer)
        {
            if (!this.gameObject.GetComponent<Rigidbody>())
            {
                audioSource.Play();
                Rigidbody rb =this.gameObject.AddComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeRotationX;
                rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            }
            wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
            //Here, the zombie's will follow the waypoint.
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            transform.LookAt(playerObj);
            //calcuateNewMovementVector();
        }
    }

    //private Vector3 movementDirection;

    /*void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = wayPoint.transform.position - this.gameObject.transform.position;
        this.gameObject.transform.rotation = Quaternion.LookRotation(movementDirection);
    }*/

}
