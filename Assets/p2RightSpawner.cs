using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2RightSpawner : MonoBehaviour
{
    private IWeapon activeWeapon;
    public GameObject prefab;
    public long i = 0;

    void Start()
    {
        activeWeapon = new p2RightSinSpawner(0.1f,  gameObject, prefab);
    }


    void FixedUpdate()
    {
        if (i == 0) { activeWeapon.Shoot(); i = -1;}
        i++;
    }
}
