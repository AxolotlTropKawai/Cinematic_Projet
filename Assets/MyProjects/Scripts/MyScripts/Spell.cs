using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public float reloadTime = 3f;
    private bool reloading;

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !reloading)
        {
            reloading = true;
            GetComponent<Animator>().SetTrigger("activate");
            StartCoroutine(waitSpell());
        }
    }
    IEnumerator waitSpell()
    {
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }
}
