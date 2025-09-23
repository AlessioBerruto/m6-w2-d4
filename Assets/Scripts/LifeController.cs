using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private UI_LifeController _uiLifeController;
    public UnityEvent onDeath;

    private int _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
        _uiLifeController.UpdateLifeBar(1f);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        float normalizedHealth = (float)_currentHealth / _maxHealth;
        _uiLifeController.UpdateLifeBar(normalizedHealth);

        if (_currentHealth <= 0)
        {
            onDeath.Invoke();

            GetComponent<PlayerController>().enabled = false;
            this.enabled = false;
        }
    }
}
