using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _lifetime = 3f;
    [SerializeField] private int _damage = 1;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 direction)
    {
        gameObject.SetActive(true);
        _rb.velocity = direction * _speed;

        StartCoroutine(DisableAfterSeconds());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LifeController life = collision.gameObject.GetComponent<LifeController>();
            if (life != null)
            {
                life.TakeDamage(_damage);
            }

            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TriggerHit();
            }
        }

        _rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }


    private IEnumerator DisableAfterSeconds()
    {
        yield return new WaitForSeconds(_lifetime);

        _rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
