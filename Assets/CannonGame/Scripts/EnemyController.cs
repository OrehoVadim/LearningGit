using CannonGame.Scripts;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _startingHealth = 100;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _collisionDamageToCannon = 25;
    
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _destructionPoint;
    
    private int _currentHealth;
    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentHealth = _startingHealth;
        if (_spawnPoint != null)
        {
            transform.position = _spawnPoint.position;
        }
        else
        {
            Debug.LogError("Spawn point is not assigned in EnemyController!");
        }
    }

    private void FixedUpdate()
    {
        MoveToDestructionPoint();
    }

    private void MoveToDestructionPoint()
    {
        if (_destructionPoint != null)
        {
            Vector3 direction = (_destructionPoint.position - transform.position).normalized;
            _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);
            if (transform.position.x <= _destructionPoint.position.x)
            {
                Debug.Log("Enemy reached destruction point. Destroying...");
                EventManager.TriggerEnemyReachedDestructionPoint(_collisionDamageToCannon);
            }
        }
        else
        {
            Debug.Log("Destruction point is not assigned!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DestructionPoint"))
        {
            Destroy(gameObject);
        }
    }
    
    public void TakeDamage(int damage)
    {
        _startingHealth -= damage;
        
        if (_startingHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

