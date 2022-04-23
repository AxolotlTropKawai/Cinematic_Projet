using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Flip 

        if (Input.GetAxis("Horizontal") > 0) GetComponent<SpriteRenderer>().flipX = false;

        else if (Input.GetAxis("Horizontal") < 0) GetComponent<SpriteRenderer>().flipX = true;
    }
}
