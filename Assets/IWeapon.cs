using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IWeapon
{
    void Shoot();
}


public class p2LeftSinSpawner : IWeapon
{
    private float fireDelay;
    private float timeSinceLastShoot;
    public GameObject owner;
    public GameObject projectilePrefab;
    private System.Random rand = new System.Random();

    public p2LeftSinSpawner(float _fireDelay, GameObject _owner, GameObject prefab)
    {
        owner = _owner;
        fireDelay = _fireDelay;
        projectilePrefab = prefab; //mine
    }

    public void Shoot()
    {
        if (Time.time > fireDelay + timeSinceLastShoot)
        {
            GameObject projectile = GameObject.Instantiate(projectilePrefab, owner.transform.position, Quaternion.identity);
            projectile.GetComponent<BaseMissileMovement>().SetMovement(new SinMovement());
            //if (rand.Next(2) == 0) projectile.GetComponent<BaseMissileMovement>().SetMovement(new SinMovement());
            //else projectile.GetComponent<BaseMissileMovement>().SetMovement(new reverseSinMovement());
            timeSinceLastShoot = Time.time;
        }
    }
}

public class p2RightSinSpawner : IWeapon
{
    private float fireDelay;
    private float timeSinceLastShoot;
    public GameObject owner;
    public GameObject projectilePrefab;
    private System.Random rand = new System.Random();

    public p2RightSinSpawner(float _fireDelay, GameObject _owner, GameObject prefab)
    {
        owner = _owner;
        fireDelay = _fireDelay;
        projectilePrefab = prefab; //mine
    }

    public void Shoot()
    {
        if (Time.time > fireDelay + timeSinceLastShoot)
        {
            GameObject projectile = GameObject.Instantiate(projectilePrefab, owner.transform.position, Quaternion.identity);
            projectile.GetComponent<BaseMissileMovement>().SetMovement(new reverseSinMovement());
            timeSinceLastShoot = Time.time;
        }
    }
}

public class p1TopSpawner : IWeapon
{
    private float fireDelay;
    private float timeSinceLastShoot;
    public GameObject owner;
    public GameObject projectilePrefab;
    private System.Random rand = new System.Random();

    public p1TopSpawner(float _fireDelay, GameObject _owner, GameObject prefab)
    {
        owner = _owner;
        fireDelay = _fireDelay;
        projectilePrefab = prefab; //mine
    }

    public void Shoot()
    {
        if (Time.time > fireDelay + timeSinceLastShoot)
        {
            GameObject projectile = GameObject.Instantiate(projectilePrefab, owner.transform.position, Quaternion.identity);
            if (rand.Next(2) == 0) projectile.GetComponent<BaseMissileMovement>().SetMovement(new SenoidalMovement());
            else projectile.GetComponent<BaseMissileMovement>().SetMovement(new reverseSenoidalMovement());
            timeSinceLastShoot = Time.time;
        }
    }
}

public class p1SideSpawner : IWeapon
{
    private float fireDelay;
    private float timeSinceLastShoot;
    public GameObject owner;
    public GameObject projectilePrefab;
    private System.Random rand = new System.Random();

    public p1SideSpawner(float _fireDelay, GameObject _owner, GameObject prefab)
    {
        owner = _owner;
        fireDelay = _fireDelay;
        projectilePrefab = prefab; //mine
    }

    public void Shoot()
    {
        if (Time.time > fireDelay + timeSinceLastShoot)
        {
            GameObject projectile = GameObject.Instantiate(projectilePrefab, owner.transform.position, Quaternion.identity);
            if (rand.Next(2) == 0) projectile.GetComponent<BaseMissileMovement>().SetMovement(new LinearMovement());
            else projectile.GetComponent<BaseMissileMovement>().SetMovement(new reverseLinearMovement());
            timeSinceLastShoot = Time.time;
        }
    }
}
