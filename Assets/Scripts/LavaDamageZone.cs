using UnityEngine;

public class LavaDamageZone : MonoBehaviour
{
    [SerializeField] private int damagePerTick = 1;
    [SerializeField] private float damageInterval = 1f;

    private bool playerInside = false;
    private float damageTimer = 0f;
    private LifeController playerLife;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerLife = other.GetComponent<LifeController>();
            playerInside = true;
            damageTimer = 0f; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            playerLife = null;
        }
    }

    private void Update()
    {
        if (playerInside && playerLife != null)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                playerLife.TakeDamage(damagePerTick);
                damageTimer = 0f;
            }
        }
    }
}
