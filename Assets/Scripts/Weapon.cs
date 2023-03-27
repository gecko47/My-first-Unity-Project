using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;
    public float bulletLifeTime;

    public void Fire()
    {
        // spawns a bullet as a GameObject "projectile". Then adds force to the bullet to make it shoot. Despawns after a few seconds
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        Destroy(projectile, bulletLifeTime);

    }
}
