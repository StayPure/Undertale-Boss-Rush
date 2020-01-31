using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    public Vector3 curScale;
    public float dmg = 0;
    public float x = 1.1f;
    public GameObject menuHealthBar;
    public void takesDamage(float x)
    {
        dmg = x;
    }

    void Update()
    {
        if (curScale.x > x - dmg)
        {
            curScale.x -= 0.001f;
            transform.GetChild(0).localScale = curScale;
            menuHealthBar.transform.GetChild(0).localScale = curScale;
        }
        else
        {
            curScale = transform.GetChild(0).localScale;
            x = curScale.x;
            dmg = 0;
        }

    }
}
