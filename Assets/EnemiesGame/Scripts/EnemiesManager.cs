using System;
using System.Collections.Generic;
using EnemiesGame;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private Vector2 _initialMinCoordinate;
    [SerializeField] private Vector2 _initialMaxCoordinate;
    [SerializeField] private List<GameObject> _botPrefab;
    [SerializeField] private float _enemyBornInterval = 0.5f;

    public List<Enemy> _enemies;
    private float _time = 0;

    private void Start()
    {
        _enemies = new List<Enemy>();
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time > _enemyBornInterval)
        {
            var x = Random.Range(_initialMinCoordinate.x, _initialMaxCoordinate.x);
            var y = Random.Range(_initialMinCoordinate.y, _initialMaxCoordinate.y);
            var initialCoordinate = new Vector2(x, y);
            var enemyIndex = Random.Range(0, _botPrefab.Count);
            var newEnemy = Instantiate(_botPrefab[enemyIndex], initialCoordinate, Quaternion.identity);
            var enemyComponent = newEnemy.GetComponent<Enemy>();
            _enemies.Add(enemyComponent); 
            _time = 0;
        }
    }
}
