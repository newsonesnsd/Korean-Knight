using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castleController : MonoBehaviour
{
    public static bool checkStatus = false;
    public float movementSpeed = 60f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int i = 1;
        if (checkStatus == true)
        {
            if (i == 1)
            {
                transform.position = transform.position + new Vector3(0, -1.0f * 80 * Time.deltaTime, 0);
                checkStatus = false;    
            }
            else
            {
                transform.position = transform.position + new Vector3(0, -1.0f * movementSpeed * Time.deltaTime, 0);
                checkStatus = false; 
            }
                
        }
        
    }

    public static bool UpdateStatus()
    {
        return checkStatus = true;
    }
}