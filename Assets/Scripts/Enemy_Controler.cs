using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controler : MonoBehaviour
{
    [SerializeField] GameObject EnemyModel;

    private Follow_the_path_script Follow_The_Path_Script;
    private Enemy Enemy;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Follow_The_Path_Script = EnemyModel.GetComponent<Follow_the_path_script>();
        Enemy = EnemyModel.GetComponent<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsRunning", true);
            Enemy.EnemyFollowThePlayer = true;
            Follow_The_Path_Script.EnemyFollowThePath = false;
        }


    }
}
