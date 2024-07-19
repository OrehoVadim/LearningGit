using CannonGame.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private Slider _healthSlider;
    private int _currentHealth;
    
    // private EnemyController _enemyController;
    // [SerializeField] private GameObject _cannonballPrefab;
    // [SerializeField] private Transform _firePoint;
    // [SerializeField] private float _fireRate = 2f;
    // [SerializeField] private float _cannonballSpeed = 10f;
    // [SerializeField] private float _searchRadius = 10f;
    // private float _nextFireTime;
    
    public void Start()
    {
        _currentHealth = _maxHealth;
        _healthSlider.targetGraphic.color = Color.green;
        UpdateHealthSlider(_currentHealth, _maxHealth);
        
        // _nextFireTime = Time.time;
    }
    
    private void OnEnable()
    {
        EventManager.OnHealsUpdate += UpdateHealthSlider;
    }

    private void OnDisable()
    {
        EventManager.OnHealsUpdate -= UpdateHealthSlider;
    }
    
    private void UpdateHealthSlider(int currentHealth, int maxHealth)
    {
        _currentHealth = currentHealth;
        _maxHealth = maxHealth;
        
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
    
    // private void Update()
    // {
        // if (_rotateUp)
        // {
        //     _currentRotation = Mathf.Lerp(_currentRotation, _maxRotation, _rotationSpeed * Time.fixedDeltaTime);
        //     if (_currentRotation >= _maxRotation - 0.1f)
        //     {
        //         _currentRotation = _maxRotation;
        //         _rotateUp = false;
        //     }
        // }
        // else
        // {
        //     _currentRotation = Mathf.Lerp(_currentRotation, _maxRotation, _rotationSpeed * Time.fixedDeltaTime);
        //     if (_currentRotation <= _minRotation + 0.1f)
        //     {
        //         _currentRotation = _minRotation;
        //         _rotateUp = true;
        //     }
        // }

        // _targetRotation = Mathf.Clamp(_currentRotation - 30 * Time.deltaTime, _maxRotation, _minRotation);
        //
        // _currentRotation = Mathf.Lerp(_currentRotation, _targetRotation, 0.1f); // 0.1f - коэффициент сглаживания
        //
        // transform.localEulerAngles = new Vector3(0, 0, _currentRotation);
        //     
        // if (Time.time > _nextFireTime || Input.GetKeyDown(KeyCode.Space))
        // {
        //     Fire();
        //     _nextFireTime = Time.time + _fireRate;
        // }
    // }

    // private void Fire()
    // {
    //     if (_firePoint != null && _cannonballPrefab != null)
    //     {
    //         GameObject cannonballInstantiate = Instantiate(_cannonballPrefab, _firePoint.position, _firePoint.rotation);
    //         Rigidbody2D cannonRigidbody2D = cannonballInstantiate.GetComponent<Rigidbody2D>();
    //
    //         if (cannonRigidbody2D != null)
    //         {
    //             cannonRigidbody2D.velocity = _firePoint.right * _cannonballSpeed;
    //         }
    //         else
    //         {
    //             Debug.LogError("Missing cannonball prefab or fire point!");
    //         }
    //     }
    //     else
    //     {
    //         Debug.LogError("_firePoint is not assigned in CannonController!");
    //     }
    // }

    // public void Awake()
    // {
    //     _maxHealth = (int)_healthSlider.maxValue;
    // }
    
    // public void TakeDamage(int damageAmount)
    // {
    //     _currentHealth -= damageAmount;
    //     if (_currentHealth <= 0)
    //     {
    //         _currentHealth = 0;
    //     }
    //     
    //     EventManager.TriggerHealthUpdate(_currentHealth, _maxHealth);
    //     UpdateHealthSlider();
    // }
    
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