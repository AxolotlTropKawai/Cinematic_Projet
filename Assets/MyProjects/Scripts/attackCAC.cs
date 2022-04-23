﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCAC : MonoBehaviour {

    public int degats = 3;
    public Vector2 attackPosition;
    private Vector2 attackPositionSave;
    public float attackRadius;
    public float reloadTime = 0.5f;
    private bool reloading;
    private Animator anim;
    private Collider2D[] target;
    private SpriteRenderer skin;

    void Start() {
        if (!PlayerPrefs.HasKey("degatCAC")) {
            PlayerPrefs.SetInt("degatCAC", degats);
        }
        degats = PlayerPrefs.GetInt("degatCAC");
        anim = GetComponent<Animator>();
        skin = GetComponent<SpriteRenderer>();
        attackPositionSave = attackPosition;
    }

    void Update() {
        if (Input.GetButtonDown("Fire1") && !reloading) {
            degats = PlayerPrefs.GetInt("degatCAC");
            reloading = true;
            anim.SetTrigger("attackCAC");

            if (!skin.flipX) {
                attackPosition = (Vector2)transform.position + new Vector2(attackPositionSave.x, attackPositionSave.y);
            }

            if (skin.flipX) {
                attackPosition = (Vector2)transform.position + new Vector2(-attackPositionSave.x, attackPositionSave.y);
            }

            target = Physics2D.OverlapCircleAll(attackPosition, attackRadius);
            foreach (Collider2D truc in target) {
                if (truc.tag == "Enemy" || truc.tag == "Door") {
                    truc.SendMessage("takeDamage", degats);
                }
            }
            StartCoroutine(waitShoot());
        }
    }

    IEnumerator waitShoot() {
        yield return new WaitForSeconds(reloadTime); // La on dit au script de patienter pendant un certain temps (reloadTime)
        reloading = false;                           // On a fini d'attendre donc on repasse reloading en vrai, donc on va pouvoir tirer à nouveau
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere((Vector2)transform.position + attackPosition, attackRadius);
    }
}
