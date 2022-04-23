using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    public string sceneName;

    // Update is called once per frame
    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D truc)
    {
        if (truc.tag == "Player")
        {
            loadScene();
        }
    }
}
