using CannonGame.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private Slider _healthSlider;
    private int _currentHealth;

    public void Start()
    {
        _currentHealth = _maxHealth;
        _healthSlider.value = 1f;
        _healthSlider.targetGraphic.color = Color.green;
        UpdateHealthSlider();
    }
    
    private void OnEnable()
    {
        EventManager.OnEnemyReachedDestructionPoint += TakeDamage;
    }
    
    private void OnDisable()
    {
        EventManager.OnEnemyReachedDestructionPoint -= TakeDamage;
    }
    
    private void UpdateHealthSlider()
    {
        _healthSlider.value = (float)_currentHealth / _maxHealth;
    
        if (_healthSlider.value > 0.5f)
        {
            _healthSlider.targetGraphic.color = Color.green;
        }
        else if (_healthSlider.value > 0.2f) // _maxHealth / 2
        {
            _healthSlider.targetGraphic.color = Color.yellow;
        }
        else
        {
            _healthSlider.targetGraphic.color = Color.red;
        }
        
        Debug.Log($"Health updated: {_currentHealth}/{_maxHealth}");
    }
    

    
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
        }
        UpdateHealthSlider();
    }
}