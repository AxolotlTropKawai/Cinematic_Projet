using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private Text timerText;
    private float startTimer;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = (Time.time - startTimer).ToString("F0");
    }
}
