using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Camera Camera;

    void Update()
    {
        if (Camera == null)
        {
            this.transform.LookAt(Camera.main.transform.position);
        }
        else
        {
            this.transform.LookAt(Camera.transform.position);
        }

    }
}
