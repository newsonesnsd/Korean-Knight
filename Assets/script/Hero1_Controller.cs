using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hero1_Controller : MonoBehaviour
{
    public float jumpSpeed;
    Rigidbody2D rb;
    public static bool checkStatus = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkStatus == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            checkStatus = false;
        }
        
    }

    public static bool UpdateStatus()
    {
        return checkStatus = true;
    }
}
