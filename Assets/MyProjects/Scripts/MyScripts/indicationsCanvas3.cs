using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicationsCanvas3 : MonoBehaviour
{
    public GameObject menuIndication;
    public GameObject indication1;
    public GameObject indication2;
    public GameObject indication3;
    public GameObject indication4;
    public GameObject indication5;
    public GameObject indication6;
    public GameObject indication7;

    // Start is called before the first frame update
    void Start()
    {
        menuIndication.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            menuIndication.SetActive(true);
            indication1.SetActive(false);
            indication2.SetActive(false);
            indication3.SetActive(true);
            indication4.SetActive(false);
            indication5.SetActive(false);
            indication6.SetActive(false);
            indication7.SetActive(false);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            menuIndication.SetActive(false);
        }
    }
}
