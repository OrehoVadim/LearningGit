using CannonGame.Scripts;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _damageToCannon = 25;
    
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _destructionPoint;

    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
            EventManager.TriggerEnemyReachedDestructionPoint(_damageToCannon);
        }
    }
}
