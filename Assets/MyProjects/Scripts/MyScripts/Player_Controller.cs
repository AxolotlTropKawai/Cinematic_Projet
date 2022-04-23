using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float vitesse;
    private bool isJumping;
    public float speedJump;

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Marche

        Vector2 vecteur = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.Translate(vecteur * vitesse * Time.deltaTime);

        // Saut

        if (Input.GetButton("Jump") && Input.GetAxis("Jump") < 1 && !isJumping)
        {
            rb2D.velocity = new Vector2(0, Input.GetAxis("Jump") * speedJump);
        }

        if (Input.GetButtonUp("Jump") || Input.GetAxis("Jump") >= 1)
        {
            isJumping = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plateform"))
        {
            isJumping = false;
        }

    }
}
