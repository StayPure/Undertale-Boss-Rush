using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSpawner : MonoBehaviour
{
    private IWeapon activeWeapon;
    public GameObject prefab;

    void Start()
    {
        activeWeapon = new p1SideSpawner(0.1f,  gameObject, prefab);
    }

    void Update()
    {
        activeWeapon.Shoot();
    }
}
