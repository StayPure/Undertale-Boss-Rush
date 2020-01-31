using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMissileMovementLL : MonoBehaviour
{
    private IMovement movementType;

    void Start()
    {
        Destroy(gameObject, 4f);
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
    }
}
