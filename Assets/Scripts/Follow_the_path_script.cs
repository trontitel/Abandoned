using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_the_path_script : MonoBehaviour
{
    public Path_Script PathToFollow;

    public int CurrentWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    //public string pathName;

    Vector3 last_position;
    Vector3 current_position;

    public bool EnemyFollowThePath = true;

    void Start()
    {
        //PathToFollow = GameObject.Find(pathName).GetComponent<Path_Script>();
        last_position = transform.position;
    }

    void Update()
    {
        if(EnemyFollowThePath)
            FollowThePath();
    }

    private void FollowThePath()
    {
        float distance = Vector3.Distance(PathToFollow.path_objects[CurrentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objects[CurrentWayPointID].position, Time.deltaTime * speed);

        var rotation = Quaternion.LookRotation(PathToFollow.path_objects[CurrentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        if (distance <= reachDistance)
        {
            CurrentWayPointID++;
        }

        if (CurrentWayPointID >= PathToFollow.path_objects.Count)
        {
            CurrentWayPointID = 0;
        }
    }
}
