using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _poolSize = 30;
    private List<Bullet> _bulletPool;

    void Start()
    {
        _bulletPool = new List<Bullet>();

        for (int i = 0; i < _poolSize; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform);
            bullet.gameObject.SetActive(false);
            _bulletPool.Add(bullet);
        }
    }

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in _bulletPool)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                return bullet;
            }
        }

        Bullet newBullet = Instantiate(_bulletPrefab, transform);
        newBullet.gameObject.SetActive(false);
        _bulletPool.Add(newBullet);
        return newBullet;
    }

}
