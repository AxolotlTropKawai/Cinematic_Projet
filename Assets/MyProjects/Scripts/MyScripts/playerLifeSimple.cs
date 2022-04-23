using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerLifeSimple : MonoBehaviour
{
    public int vie = 1;
    private int vieMax;
    public Slider barreDeVie;
    public GameObject canvasDeath;

    // Start is called before the first frame update
    void Start()
    {
        vieMax = vie;
        barreDeVie.value = ((float)vie / (float)vieMax) * 100;
    }

    public void takeDamage(int damage)
    {
        vie = vie - damage;
        barreDeVie.value = ((float)vie / (float)vieMax) * 100;
        if (vie <= 0)
        {
            canvasDeath.SetActive(true);
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<control_V2>());
            // GetComponent<Animator>().SetTrigger("dead");
            StartCoroutine(respawn());
        }
    }

    public void takeHeal(int heal)
    {
        vie = vie + heal;
        if (vie > vieMax)
        {
            vie = vieMax;
        }
        barreDeVie.value = ((float)vie / (float)vieMax) * 100;
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(1f);
        reloadScene();
    }
    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
