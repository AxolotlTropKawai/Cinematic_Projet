using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject menuPause;

    void Start()
    {
        menuPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stopHammerTime();
        }
    }

    public void stopHammerTime()
    {
        if (!menuPause.activeSelf)
        {
            menuPause.SetActive(true);
            Time.timeScale = 0;
        }
        else if (menuPause.activeSelf)
        {
            menuPause.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void retourMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
