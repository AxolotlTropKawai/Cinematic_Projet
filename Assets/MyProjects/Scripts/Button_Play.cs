using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Play : MonoBehaviour
{
    public void loadLevel ()
    {
        SceneManager.LoadScene("First_Level");
    }
}
