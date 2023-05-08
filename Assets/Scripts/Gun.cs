using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource shotSound;
    public AudioSource reloadSound;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float currentAmmo = 30f;
    public float maxAmmo = 30f;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            Spawner spawner = hitInfo.transform.GetComponent<Spawner>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            if (spawner != null)
            {
                spawner.TakeDamage(damage);
            }
        }
        shotSound.Play();
        currentAmmo--;
    }

    void Reload()
    {
        reloadSound.Play();
        currentAmmo = maxAmmo;
    }
}
