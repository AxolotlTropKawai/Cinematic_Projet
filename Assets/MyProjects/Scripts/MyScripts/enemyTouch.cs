using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTouch : MonoBehaviour
{
    public int degats = 1;
    void OnCollisionEnter2D(Collision2D truc)
    {
        if (truc.gameObject.tag == "Player")
        {
            truc.gameObject.GetComponent<playerLifeSimple>().takeDamage(degats);
        }
    }
}