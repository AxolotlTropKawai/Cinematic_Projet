using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tiktak : MonoBehaviour
{
    public float compteARebours;
    private Text timerText;
    private float startTimer;
    private float calculTimer;
    public GameObject canvasDeath;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        calculTimer = compteARebours - (Time.time - startTimer);
        if (calculTimer > 0)
        {
            timerText.text = calculTimer.ToString("F2");
        }
        if (calculTimer <= 0)
        {
            canvasDeath.SetActive(true);
            StartCoroutine(respawn());
        }
    }
    IEnumerator respawn()
    {
        yield return new WaitForSeconds(2f);
        reloadScene();
    }
    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
