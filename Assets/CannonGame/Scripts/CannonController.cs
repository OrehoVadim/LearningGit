using System.Collections;
using CannonGame.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _cannonCorePrefab;
    [SerializeField] private float _fireInterval = 1f;
    
    private float _currentHealth;
    private GameObject _currentTargetEnemy;
    private bool _canFire = true;

    public void Start()
    {
        _currentHealth = _maxHealth;
        _healthSlider.value = _currentHealth / _maxHealth;
        _healthSlider.targetGraphic.color = Color.green;
        UpdateHealthSlider();
        
        StartCoroutine(AutomaticFire());
    }
    
    private IEnumerator AutomaticFire()
    {
        while (true)
        {
            if (_canFire)
            {
                FireCannon();
                _canFire = false;
                yield return new WaitForSeconds(_fireInterval);
                _canFire = true;
            }
            yield return null;
        }
    }

    public void FireCannon()
    {
        GameObject cannonBall = Instantiate(_cannonCorePrefab, _firePoint.position, Quaternion.identity); // firePoint.rotation 
        CannonCore cannonCore = cannonBall.GetComponent<CannonCore>();
        
        if (cannonCore != null)
        {
            cannonCore.SetInitialVelocity(_firePoint.right * cannonCore.GetSpeed());
        }
        else
        {
            Debug.LogError("CannonCore component not found on cannonBall.");
        }
    }

    private void OnEnable()
    {
        EventManager.OnEnemyReachedDestructionPoint += TakeDamage;
        Debug.Log("EventManager.OnEnemyReachedDestructionPoint subscribed.");
    }
    
    private void OnDisable()
    {
        EventManager.OnEnemyReachedDestructionPoint -= TakeDamage;
        Debug.Log("EventManager.OnEnemyReachedDestructionPoint unsubscribed.");
    }
    
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Damage taken: {damage}. Current Health: {_currentHealth}");
        
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
        }
        UpdateHealthSlider();
    }
    
    private void UpdateHealthSlider()
    {
        _healthSlider.value = _currentHealth / _maxHealth;
        Debug.Log($"Slider value updated: {_healthSlider.value}");
    
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
}