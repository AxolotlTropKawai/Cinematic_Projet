using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levier : MonoBehaviour {

    // Ce script se met sur le levier qui permettra au joueur d'ouvrir la porte
    // ATTENTION il marche en binome avec un autre script : le script "porte"

    public GameObject porte; // Il faudra drag'n drop la "porte" que l'on souhaite ouvrir dans cette variable (depuis l'éditeur)


    // Tant que le joueur reste dans ce trigger, si il appuis sur la touche "E" du clavier, ça lance la fonction "ouverture" qui se trouve sur cette porte
    void OnTriggerStay2D(Collider2D truc) {
        if (truc.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.E)) {
                GetComponent<Animator>().SetTrigger("activate");
                porte.GetComponent<porte>().ouverture();
            }
        }
    }
}
