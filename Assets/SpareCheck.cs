using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpareCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "bullet")
        {
            //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        }
    }
}
