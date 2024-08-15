using System;
using System.Collections;
using CannonGame.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class CannonManager : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _cannonCorePrefab;
    
    private float _currentHealth;
    private GameObject _currentTargetEnemy;

    public void Start()
    {
        _currentHealth = _maxHealth;
        _healthSlider.value = _currentHealth / _maxHealth;
        _healthSlider.targetGraphic.color = Color.green;
        
        UpdateHealthSlider();
    }

    private void Update()
    {
        RotateTowardsMouse();

        if (Input.GetMouseButtonDown(0))
        {
            FireCannon();
        }
    }

    private void RotateTowardsMouse()
    {
        Vector3 MouseShotPoint = Input.mousePosition;
        MouseShotPoint.z = -Camera.main.transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(MouseShotPoint);
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -45f, 45f);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
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
        _healthSlider.value = _currentHealth;
        Debug.Log($"Slider value updated: {_healthSlider.value}");
    
        if (_healthSlider.value > 50)
        {
            _healthSlider.targetGraphic.color = Color.green;
        }
        else if (_healthSlider.value > 20)
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
