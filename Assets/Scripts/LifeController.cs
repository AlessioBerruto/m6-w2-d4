using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private UI_LifeController _uiLifeController;

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

        Debug.Log($"Player took damage: {damage}, current health: {_currentHealth}");

        float normalizedHealth = (float)_currentHealth / _maxHealth;
        _uiLifeController.UpdateLifeBar(normalizedHealth);

        if (_currentHealth <= 0)
        {
            Debug.Log("Player is dead");

            MenuManager menu = FindObjectOfType<MenuManager>();
            if (menu != null)
            {
                menu.Lose();
            }

            GetComponent<PlayerController>().enabled = false;
            this.enabled = false;
        }
    }
}
