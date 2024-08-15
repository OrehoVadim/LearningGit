using System.Collections.Generic;
using CannonGame.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _destructionPoint;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _pirateFirePoint;
    [SerializeField] private List<Enemy> _enemyPrefabs;
    [SerializeField] private float _enemyBornInterval = 1f;

    private float _time = 0;
    private List<Enemy> _enemiesPrefabs;

    private string[] _enemyTags = { "Hunter", "Ninja", "Ork", "PirateCannon" };
    
    private void Awake()
    {
        _enemiesPrefabs = new List<Enemy>();
    }

    private void Start()
    {
        Debug.Log($"Initial number of enemy prefabs: {_enemyPrefabs?.Count ?? 0}");
        ValidateEnemyPrefabs();
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

        List<Enemy> validPrefabs = new List<Enemy>(_enemyPrefabs);
        
        HashSet<string> activeEnemyTags = new HashSet<string>();

        foreach (var tag in _enemyTags)
        {
            if (GameObject.FindGameObjectWithTag(tag) != null)
            {
                activeEnemyTags.Add(tag);
            }
        }
        
        
        // if (IsPirateCannonActivePresent())
        // {
        //     validPrefabs.RemoveAll(prefab => prefab is PirateCannon);
        //     Debug.Log($"Valid prefabs count after filtering: {validPrefabs.Count}");
        //     
        //     if (validPrefabs.Count == 0)
        //     {
        //         Debug.LogWarning("No valid enemy prefabs available to spawn.");
        //         return;
        //     }
        // }

        if (validPrefabs.Count > 0)
        {
            int prefabIndex = Random.Range(0, validPrefabs.Count);
            Debug.Log($"Selected prefab index: {prefabIndex}");
            
            Enemy enemyPrefab = validPrefabs[prefabIndex];

            if (enemyPrefab == null)
            {
                Debug.LogError("Selected enemy prefab is null.");
                return;
            }

            if (IsEnemyTypeActive(enemyPrefab))
            {
                Debug.Log($"An enemy of type {enemyPrefab.name} is already active. Skipping spawn.");
                return;
            }

            if (_enemiesPrefabs.Count > 0)
            {
                var enemy = _enemiesPrefabs[0];
                _enemiesPrefabs.RemoveAt(0);
                enemy.transform.position = _spawnPoint.position;
                enemy.gameObject.SetActive(true);
            }
            else
            {
                var newEnemy = Instantiate(enemyPrefab, _spawnPoint.position, Quaternion.identity);
                if (newEnemy is PirateCannon _pirateCannon)
                {
                    _pirateCannon.Initialize(_pirateFirePoint, this);
                }
                else
                {
                    newEnemy.Initialize(_destructionPoint, this);
                }
            }
            Debug.Log($"Spawned enemy of type {enemyPrefab.gameObject.tag}.");
        }
        else
        {
            Debug.Log("All enemy types are already active on the field.");
        }
    }

    private bool IsEnemyTypeActive(Enemy enemyPrefab)
    {
        foreach (var tag in _enemyTags)
        {
            if (GameObject.FindGameObjectWithTag(tag) != null)
            {
                if (enemyPrefab.gameObject.tag == tag)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void ValidateEnemyPrefabs()
    {
        if (_enemyPrefabs == null)
        {
            Debug.LogError("Enemy prefabs list is not assigned.");
        }
        else if (_enemyPrefabs.Count == 0)
        {
            Debug.LogWarning("Enemy prefabs list is empty.");
        }
        else
        {
            for (int i = 0; i < _enemyPrefabs.Count; i++)
            {
                if (_enemyPrefabs[i] == null)
                {
                    Debug.LogError($"Enemy prefab at index {i} is null.");
                }
            }
        }
    }

    public void PutToObjectsPull(Enemy enemy)
    {
        if (enemy != null)
        {
            _enemiesPrefabs.Add(enemy);
        }
    }

    // private bool IsPirateCannonActivePresent()
    // {
    //     foreach (var cannon in FindObjectsOfType<PirateCannon>())
    //     {
    //         if (cannon != null && PirateCannon.IsPirateCannonActive)
    //         {
    //             return true;
    //         }
    //     }
    //     return false;
    // }
}
