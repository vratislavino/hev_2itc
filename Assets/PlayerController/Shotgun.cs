using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private int bulletCount;

    [SerializeField]
    private float spread;

    protected override void Shoot() {

        for (int i = 0; i < bulletCount; i++) {
            var bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(GetDirection() * bulletSpeed, ForceMode.Impulse);
        }


        CurrPocetNaboju--;
        currShootCooldown = shootCooldown;
    }

    private Vector3 GetDirection() {
        Vector3 dir = transform.forward;

        dir.x += Random.Range(-spread, spread);
        dir.y += Random.Range(-spread, spread);
        dir.z += Random.Range(-spread, spread);

        return dir;
    }

}
