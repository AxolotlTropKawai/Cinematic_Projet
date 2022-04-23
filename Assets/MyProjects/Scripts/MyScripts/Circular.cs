using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular : MonoBehaviour
{

    public float RotateSpeed = 5f;
    private float speedSave;
    public float Radius = 0.1f;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        speedSave = RotateSpeed;
        _centre = transform.position;
    }

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }

    //Si notre joueur touche cette plateform, il deviendra automatiquement son "enfant" et donc la suivra partout
    void OnCollisionEnter2D(Collision2D truc)
    {
        if (truc.gameObject.tag == "Player")
        {
            truc.transform.parent = transform;
        }
    }

    //Si notre joueur quitte cette plateform, il arrêtera d'être son "enfant" et donc ne bougera plus avec la plateforme
    void OnCollisionExit2D(Collision2D truc)
    {
        if (truc.gameObject.tag == "Player")
        {
            truc.transform.parent = null;
        }
    }
    public void slowMotion()
    {
        RotateSpeed = RotateSpeed / 4f;
        StartCoroutine(slowEnd());
    }

    IEnumerator slowEnd()
    {
        yield return new WaitForSeconds(3f);
        RotateSpeed = speedSave;
    }

}
