using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgend : MonoBehaviour
{
    void animationEnd()
    {
        GetComponent<Animator>().SetBool("hit", false);
    }
}
