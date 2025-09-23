using UnityEngine;

public class DeathZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MenuManager menu = FindObjectOfType<MenuManager>();
            if (menu != null)
            {
                menu.Lose();
            }

            PlayerController controller = other.GetComponent<PlayerController>();
            if (controller != null)
            {
                controller.enabled = false;
            }

            LifeController life = other.GetComponent<LifeController>();
            if (life != null)
            {
                life.enabled = false;
            }
        }
    }
}
