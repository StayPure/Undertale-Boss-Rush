using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMissileMovement : MonoBehaviour
{
    private IMovement movementType;
    public float time;

    void Start()
    {
        Destroy(gameObject, time);
    }

    void Update()
    {
        movementType.Move(gameObject);
    }

    public void SetMovement(IMovement _movementType)
    {
        movementType = _movementType;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "battleHeart") 
        {
            Destroy(gameObject, 0);
        }
        else if (col.gameObject.layer == 10)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
