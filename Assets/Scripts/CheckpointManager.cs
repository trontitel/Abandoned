using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Transform ActiveCheckpoint;
    public GameObject playerObj;
    [SerializeField] PlayerCam PlayerScript;
    [SerializeField] ChaseEvent chaseEvent;

    public GameObject[] Enemies;
    public GameObject[] CameraRolls;
    public SwitchScript[] Switches;

    public int photoNumber = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void Respawn()
    {
        playerObj.transform.position = ActiveCheckpoint.position;
        PlayerScript.CameraTollNum = photoNumber;
        CameraRollsRespawn();
        SwitchReset();

        for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].SetActive(true);

            if (Enemies[i].transform.GetChild(0).GetComponent<Rigidbody>())
            {
                Destroy(Enemies[i].transform.GetChild(0).GetComponent<Rigidbody>());
            }
            Animator anim = Enemies[i].transform.GetChild(0).GetChild(0).GetComponent<Animator>();
            anim.SetBool("IsRunning", false);

            Enemy enemy = Enemies[i].transform.GetChild(0).GetComponent<Enemy>();
            Follow_the_path_script follow_The_Path_Script = Enemies[i].transform.GetChild(0).GetComponent<Follow_the_path_script>();

            enemy.EnemyFollowThePlayer = false;
            follow_The_Path_Script.EnemyFollowThePath = true;

            Enemies[i].transform.GetChild(0).transform.position = Enemies[i].transform.GetChild(1).transform.position;
        }

        if (ActiveCheckpoint.name == "4")
        {
            chaseEvent.Enemy1.transform.GetChild(0).transform.position = chaseEvent.Enemy1.transform.GetChild(1).transform.position;
            chaseEvent.Enemy2.transform.GetChild(0).transform.position = chaseEvent.Enemy2.transform.GetChild(1).transform.position;
            chaseEvent.Enemy3.transform.GetChild(0).transform.position = chaseEvent.Enemy3.transform.GetChild(1).transform.position;
            chaseEvent.Enemy1.SetActive(false);
            chaseEvent.Enemy2.SetActive(false);
            chaseEvent.Enemy3.SetActive(false);

        }
    }

    public void CameraRollsRespawn()
    {
        if (ActiveCheckpoint.name == "1")
        { 
        
        }
        if (ActiveCheckpoint.name == "2")
        {
            CameraRolls[1].SetActive(true);
        }
        if (ActiveCheckpoint.name == "3")
        {
            CameraRolls[2].SetActive(true);
            CameraRolls[3].SetActive(true);
        }
        if (ActiveCheckpoint.name == "4")
        {

        }
    }



    public void SwitchReset()
    {
        if (ActiveCheckpoint.name == "1")
        {

        }
        if (ActiveCheckpoint.name == "2")
        {
            if (Switches[0].switchDown)
            {
                Switches[0].Reset();
            }
        }
        if (ActiveCheckpoint.name == "3")
        {
            if (Switches[1].switchDown)
            {
                Switches[1].Reset();
            }
        }
        if (ActiveCheckpoint.name == "4")
        {

        }
    }
}
