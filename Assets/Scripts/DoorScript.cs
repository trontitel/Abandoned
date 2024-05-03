using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] SwitchScript switch_script;
    [SerializeField] GameObject DoorObj;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (switch_script.switchDown)
        {
            if(DoorObj)
            DoorObj.SetActive(false);
        }
        if (!switch_script.switchDown)
        {
            //if (!DoorObj)
                DoorObj.SetActive(true);
        }

    }
}
