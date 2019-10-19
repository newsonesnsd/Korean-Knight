using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public Text timer;
    public int time = 25;

    void Start()
    {
        StartCoroutine("countdownTime");
    }

    void Update()
    {
        timer.text = time.ToString();
        if (time == 0)
        {
            timer.text = "TIME UP";
            StopCoroutine("countdownTime");
        }

       
    }
 IEnumerator countdownTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.25f);
                time--;
            }
        }

} 
