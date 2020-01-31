using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topSpawner : MonoBehaviour
{
    private IWeapon activeWeapon;
    public GameObject prefab;
    public long i = 0;

    void Start()
    {
        activeWeapon = new p1TopSpawner(0.1f,  gameObject, prefab);
    }


    void FixedUpdate()
    {
        if (i == 20) { activeWeapon.Shoot(); i = -1;}
        i++;
    }
}
