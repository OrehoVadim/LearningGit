using System.Collections.Generic;
using CannonGame.Scripts;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _startingHealth;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _collisionDamageToCannon;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _destructionPoint;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private float _enemyBornInterval = 1f;

    private float _time = 0;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
    }

    private void Start()
    {
        Debug.Log($"Initial number of enemy prefabs: {_enemyPrefabs?.Count ?? 0}");
        if (_enemyPrefabs == null)
        {
            Debug.LogError("Enemy prefabs list is not assigned.");
        }
        else if (_enemyPrefabs.Count == 0)
        {
            Debug.LogWarning("Enemy prefabs list is empty.");
        }
        _time = _enemyBornInterval;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time > _enemyBornInterval)
        {
            SpawnEnemy();
            _time = 0;
        }
    }

    private void SpawnEnemy()
    {
        Debug.Log("Spawning enemy!");
        if (_spawnPoint == null)
        {
            Debug.LogError("Spawn point is not assigned.");
            return;
        }
        if (_enemyPrefabs == null || _enemyPrefabs.Count == 0)
        {
            Debug.LogError("Enemy prefabs list is empty or not assigned.");
            return;
        }

        // Убедитесь, что мы не создаем PirateCannon, если он уже активен
        if (IsPirateCannonActivePresent())
        {
            // Исключаем PirateCannon из списка префабов
            List<GameObject> validPrefabs = new List<GameObject>(_enemyPrefabs);
            validPrefabs.RemoveAll(prefab => prefab.GetComponent<PirateCannonController>() != null);

            if (validPrefabs.Count == 0)
            {
                Debug.LogWarning("No valid enemy prefabs available to spawn.");
                return;
            }

            int prefabIndex = Random.Range(0, validPrefabs.Count);
            GameObject enemyPrefab = validPrefabs[prefabIndex];

            if (enemyPrefab == null)
            {
                Debug.LogError("Selected enemy prefab is null.");
                return;
            }

            Instantiate(enemyPrefab, _spawnPoint.position, Quaternion.identity);
            Debug.Log("Enemy instantiated.");
        }
        else
        {
            int prefabIndex = Random.Range(0, _enemyPrefabs.Count);
            GameObject enemyPrefab = _enemyPrefabs[prefabIndex];

            if (enemyPrefab == null)
            {
                Debug.LogError("Selected enemy prefab is null.");
                return;
            }

            Instantiate(enemyPrefab, _spawnPoint.position, Quaternion.identity);
            Debug.Log("Enemy instantiated.");
        }
    }

    private bool IsPirateCannonActivePresent()
    {
        // Проверяем наличие активного PirateCannon
        foreach (var cannon in FindObjectsOfType<PirateCannonController>())
        {
            if (PirateCannonController.IsPirateCannonActive)
            {
                return true;
            }
        }
        return false;
    }

    private void FixedUpdate()
    {
        MoveToDestructionPoint();
    }

    private void MoveToDestructionPoint()
    {
        if (_destructionPoint != null)
        {
            Vector2 direction = new Vector2(_destructionPoint.position.x - transform.position.x, 0).normalized;
            _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);
            if (transform.position.x <= _destructionPoint.position.x)
            {
                Debug.Log("Enemy reached destruction point");
                EventManager.TriggerEnemyReachedDestructionPoint(_collisionDamageToCannon);
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("Destruction point is not assigned!");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CannonCore"))
        {
            Debug.Log("Enemy hit by cannon core");

            EventManager.TriggerEnemyDestroyed(gameObject);
            Destroy(gameObject);
        }
        
        if (collision.CompareTag("DestructionPoint"))
        {
            Debug.Log("Enemy reached destruction point");
            EventManager.TriggerEnemyReachedDestructionPoint(_collisionDamageToCannon);

            Destroy(gameObject);
        }
    }
}
