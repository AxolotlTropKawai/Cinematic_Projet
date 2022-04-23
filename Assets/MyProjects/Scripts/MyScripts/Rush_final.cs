using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_final : MonoBehaviour
{
    public GameObject final;
    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        final.SetActive(false);
        timer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D truc)
    {
        if (truc.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<Animator>().SetTrigger("activate");
                final.SetActive(true);
                timer.SetActive(true);
            }
        }
    }
}
