using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 25f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private BulletPoolManager poolManager;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private ParticleSystem muzzleFlash;

    private float fireCooldown = 0f;
    private Transform player;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        if (hits.Length > 0)
            player = hits[0].transform;
        else
            player = null;

        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0f;
            transform.forward = direction;

            if (fireCooldown <= 0f)
            {
                Fire();
                fireCooldown = 1f / fireRate;
            }
        }

        fireCooldown -= Time.deltaTime;
    }

    private void Fire()
    {

        Bullet bullet = poolManager.GetBullet();
        bullet.transform.position = firePoint.position;
        Vector3 targetPos = player.position + Vector3.up * 1.2f;
        Vector3 dir = (targetPos - firePoint.position).normalized;

        bullet.Shoot(dir);

        if (muzzleFlash != null)
            muzzleFlash.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
