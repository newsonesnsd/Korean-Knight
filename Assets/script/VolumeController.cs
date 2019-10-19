using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Image handleSound1;
    public Image handleSound2;
    public Image handleSound3;
    // Start is called before the first frame update
    void Start()
    {
        handleSound1.gameObject.SetActive(false);
        handleSound2.gameObject.SetActive(false);
        handleSound3.gameObject.SetActive(false);
    }

    public void onClick()
    {
            handleSound1.gameObject.SetActive(true);
            handleSound2.gameObject.SetActive(true);
            handleSound3.gameObject.SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
