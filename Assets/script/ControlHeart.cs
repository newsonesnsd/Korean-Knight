using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHeart : MonoBehaviour
{
    public ControlHeart heart1, heart2, heart3;
    public static int heart;
    // Start is called before the first frame update
    void Start()
    {
        heart = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        //gameOver.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (heart > 3)
            heart = 3;
        switch (heart) {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                //gameOver.gameObject.SetActive(false);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                //gameOver.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                //gameOver.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                //gameOver.gameObject.SetActive(true);
                break;
        }        
    }
}
