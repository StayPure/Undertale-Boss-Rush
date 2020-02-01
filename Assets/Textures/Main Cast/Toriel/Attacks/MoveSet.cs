using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSet : MonoBehaviour
{
    public Vector2 spawnOffset; //optional, but if you need this, best put it here  
    public Move[] moves;  
    private int currentMove = 0;
    private float moveTime;  

bool execute(float stepSize, Transform avatar) {  
  moves[currentMove].execute(stepSize, avatar);  
  moveTime += stepSize;  
  if (moveTime >= moves[currentMove].duration) {  
    currentMove += 1;  
    moveTime = 0;  
    if (currentMove >= moves.Length)  
      return true; //move set finished - repeat set or despawn enemy etc.  
  }  
  return false;  
}   
}
