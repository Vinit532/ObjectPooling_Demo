using UnityEngine;

public class GunController : MonoBehaviour
{
    public ObjectPool bulletPool; // Reference to the ObjectPool
    public Transform firePoint; // Point from which bullets are fired
    public float bulletSpeed = 20f; // Speed of the bullets

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left mouse button
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject bullet = bulletPool.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * bulletSpeed; // Move bullet
        }
    }
}
