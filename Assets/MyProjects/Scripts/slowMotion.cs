using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMotion : MonoBehaviour
{
    public float radiusSlowmotion = 10f;
    private Collider2D[] trucSlow;
    public float reloadTime = 3f;
    private bool reloading;

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !reloading)
        {
            reloading = true;
            trucSlow = Physics2D.OverlapCircleAll(transform.position, radiusSlowmotion);

            foreach (Collider2D truc in trucSlow)
            {
                truc.gameObject.SendMessage("slowMotion", SendMessageOptions.DontRequireReceiver);
            }
            StartCoroutine(waitShoot());
        }
    }
    IEnumerator waitShoot()
    {
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radiusSlowmotion);
    }
}
