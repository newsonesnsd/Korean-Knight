using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    // Start is called before the first frame update
    public Text emailText;
    void Start()
    {
        emailText.text = User.usermail;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
