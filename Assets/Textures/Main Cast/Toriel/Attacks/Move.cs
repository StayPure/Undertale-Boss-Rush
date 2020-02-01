using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector2 velocity;  
    public float angularVelocity;  
    public float duration;

    public void execute (float stepSize, Transform avatar) {
        avatar.Translate(avatar.forward * velocity * stepSize);
    }
}
