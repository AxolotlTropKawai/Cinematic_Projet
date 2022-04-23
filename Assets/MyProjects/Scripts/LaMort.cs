using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LaMort : MonoBehaviour
{
    public int mesPV = 6;
    private int mesPVMAX;
    public GameObject vie1;
    public GameObject vie2;
    public GameObject vie3;
    public GameObject vie4;
    public GameObject vie5;
    public GameObject vie6;
    private bool invincible;
    public GameObject canvasDeath;
    private Animator anim;

    private void Start()
    {
        mesPVMAX = mesPV;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (mesPV == 6)
        {
            vie1.gameObject.SetActive(true);
            vie2.gameObject.SetActive(true);
            vie3.gameObject.SetActive(true);
            vie4.gameObject.SetActive(true);
            vie5.gameObject.SetActive(true);
            vie6.gameObject.SetActive(true);
        }

        if (mesPV == 5)
        {
            vie1.gameObject.SetActive(true);
            vie2.gameObject.SetActive(true);
            vie3.gameObject.SetActive(true);
            vie4.gameObject.SetActive(true);
            vie5.gameObject.SetActive(true);
            vie6.gameObject.SetActive(false);
        }

        if (mesPV == 4)
        {
            vie1.gameObject.SetActive(true);
            vie2.gameObject.SetActive(true);
            vie3.gameObject.SetActive(true);
            vie4.gameObject.SetActive(true);
            vie5.gameObject.SetActive(false);
            vie6.gameObject.SetActive(false);
        }

        if (mesPV == 3)
        {
            vie1.gameObject.SetActive(true);
            vie2.gameObject.SetActive(true);
            vie3.gameObject.SetActive(true);
            vie4.gameObject.SetActive(false);
            vie5.gameObject.SetActive(false);
            vie6.gameObject.SetActive(false);
        }

        if (mesPV == 2)
        {
            vie1.gameObject.SetActive(true);
            vie2.gameObject.SetActive(true);
            vie3.gameObject.SetActive(false);
            vie4.gameObject.SetActive(false);
            vie5.gameObject.SetActive(false);
            vie6.gameObject.SetActive(false);
        }

        if (mesPV == 1)
        {
            vie1.gameObject.SetActive(true);
            vie2.gameObject.SetActive(false);
            vie3.gameObject.SetActive(false);
            vie4.gameObject.SetActive(false);
            vie5.gameObject.SetActive(false);
            vie6.gameObject.SetActive(false);
        }

        if (mesPV <= 0)
        {
            canvasDeath.SetActive(true);
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<control_V2>());
            // GetComponent<Animator>().SetTrigger("dead");
            StartCoroutine(respawn());
        }
        
    }

    void OnTriggerEnter2D(Collider2D trucQuiMeTraverse)
    {

        if (trucQuiMeTraverse.gameObject.tag == "Potion" && mesPV < mesPVMAX)
        {
            Destroy(trucQuiMeTraverse.gameObject);
            mesPV++;
        }
        if (trucQuiMeTraverse.gameObject.tag == "Malus")
        {
            Destroy(trucQuiMeTraverse.gameObject);
            mesPV--;
        }
        if (trucQuiMeTraverse.gameObject.tag == "Death")
        {
            mesPV = 0;
        }
    }

    void OnCollisionStay2D(Collision2D trucQuiMeTouche)
    {
        if (trucQuiMeTouche.gameObject.tag == "Enemy" && !invincible)
        {
            mesPV--;
            invincible = true;
            StartCoroutine(waiting());
        }
    }
    void OnCollisionEnter2D(Collision2D trucQueJeTouche)
    {
        if (trucQueJeTouche.gameObject.tag == "Enemy" && !invincible)
        {
            mesPV--;
            invincible = true;
            StartCoroutine(waiting());
        }

        if (trucQueJeTouche.gameObject.tag == "Death")
        {
            mesPV = 0;
        }
    }
    IEnumerator waiting()
    {
        anim.SetTrigger("ouch");
        yield return new WaitForSeconds(1f);
        invincible = false;
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
