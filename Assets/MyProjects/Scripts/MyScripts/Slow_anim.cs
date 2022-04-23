using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_anim : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void slowMotion()
    {
        anim.speed = 0.25f;
        StartCoroutine(slowEnd());
    }

    IEnumerator slowEnd()
    {
        yield return new WaitForSeconds(3f);
        anim.speed = 1f;
    }
}
