using UnityEngine;
using UnityEngine.Events;

public class DeathZoneTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent onPlayerDeath;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerDeath.Invoke();

            PlayerController controller = other.GetComponent<PlayerController>();
            if (controller != null) controller.enabled = false;

            LifeController life = other.GetComponent<LifeController>();
            if (life != null) life.enabled = false;
        }
    }
}
