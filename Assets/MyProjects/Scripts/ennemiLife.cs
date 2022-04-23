using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemiLife : MonoBehaviour {

    public int vie = 3;
    private Animator anim;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (vie <= 0) {
            anim.SetTrigger("dead");
            if (GetComponent<ennemiPatrol>() != null) {
                GetComponent<ennemiPatrol>().enabled = false;
            }
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(waitDeath());
        }
    }

    public void takeDamage (int damage) {
        vie = vie - damage;
        anim.SetTrigger("ouch");
    }
    IEnumerator waitDeath()
    {
        anim.SetTrigger("dead");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
