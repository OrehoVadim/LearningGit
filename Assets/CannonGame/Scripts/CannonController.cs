using System;
using CannonGame.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private Slider _healthSlider;

    private EnemyController _enemyController;
    private int _currentHealth;
    // private Vector3 _position;

    public void Awake()
    {
        _maxHealth = (int)_healthSlider.maxValue;
    }

    public void Start()
    {
        _currentHealth = _maxHealth;
        _healthSlider.targetGraphic.color = Color.green;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
        }
        
        EventManager.TriggerHealthUpdate(_currentHealth, _maxHealth);
        UpdateHealthSlider();
    }
        
    private void UpdateHealthSlider()
    {
        _healthSlider.value = _currentHealth / _maxHealth;

        if (_healthSlider.value > _maxHealth / 2)
        {
            _healthSlider.targetGraphic.color = Color.yellow;
        }
        else if (_healthSlider.value <= _maxHealth / 2)
        {
            _healthSlider.targetGraphic.color = Color.red;
        }
    }
    
    // private EnemyController FindEnemy()
    // {
        // GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        // if (enemyObject != null)
        // {
        //     return enemyObject.GetComponent<EnemyController>();
        // }
        // return null;
    // }

    // private void OnDestroy()
    // {
    // }
}