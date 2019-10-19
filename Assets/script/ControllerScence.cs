using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScence : MonoBehaviour
{
    public void LoadScene(string scenename) {
        SceneManager.LoadScene(scenename);
    }

    public void LoadScene1(string scenename)
    {
        SceneManager.LoadScene(scenename);
        PlayerPrefs.SetString("CategoryID", "C1");
    }

    public void LoadScene2(string scenename)
    {
        SceneManager.LoadScene(scenename);
        PlayerPrefs.SetString("CategoryID", "C2");
    }
    public void LoadScene3(string scenename)
    {
        SceneManager.LoadScene(scenename);
        PlayerPrefs.SetString("CategoryID", "C3");
    }

    public void LoadScene4(string scenename)
    {
        SceneManager.LoadScene(scenename);
        PlayerPrefs.SetString("CategoryID", "C4");
    }

    public void LoadScene5(string scenename)
    {
        SceneManager.LoadScene(scenename);
        PlayerPrefs.SetString("CategoryID", "C5");
    }

    public void LoadScene6(string scenename)
    {
        SceneManager.LoadScene(scenename);
        PlayerPrefs.SetString("CategoryID", "C6");
    }

    public void ExitGame() {
        Application.Quit();
    }


}
