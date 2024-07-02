using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace EnemiesGame
{
    public class Enemy : MonoBehaviour // Класс, представляющий врага (Enemy)
    {
        [SerializeField] private int hp;
        [SerializeField] private int armor;
        [SerializeField] private float chanceToEvade = 33; // Шанс врага увернуться
        [SerializeField] private float speed; // Скорость движения врага
        [SerializeField] private SpriteRenderer _health; // Скорость движения врага

        private bool _evaded;
        private float _maxHp;
        private float _initialHealthBarWidth;
        public Vector3 position;

        // private GameObject _explosion;

        // public delegate void MyDelegate();
        // public event MyDelegate MyEvent;
        // public event Action Died; // Делегат с множеством перегрузок - полиморфизм
        

        public void Awake()
        {
            _maxHp = hp;
            _initialHealthBarWidth = _health.size.x;
        }

        public void Update() 
        {
            transform.Translate(Vector3.down * (Time.deltaTime * speed));  // Перемещение врага вперед с заданной скоростью
            if (_evaded)
            {
                var vectorToEvade = Random.Range(1, 3) == 1 ? Vector3.left : Vector3.right;
                transform.Translate(vectorToEvade * 0.25f );
                _evaded = false;
            }
        }
        

        public void GetDamage(int damage) // Метод для получения урона врагом (Enemy)
        {
            int random = Random.Range(1, 101);
            Debug.Log($"Random number = {random}");
            if (chanceToEvade > 0)    // Проверить возможность уворота врага (и если шанс уворота не положителен)
            {
                if (random <= chanceToEvade) // Проверить случайное число (от 1 до 100)
                {
                    _evaded = true;
                    return; // Враг увернулся от атаки
                }
            }

            if (armor > 0) // Если у врага есть броня
            {
                damage -= armor; // Уменьшить броню на количество урона 
            }

            if (damage <= 0)
                return;
            
            hp -= damage; // Нанести урон здоровью врага 
            float healthPercent = hp / _maxHp;
            Vector3 newScale = _health.size;
            newScale.x = _initialHealthBarWidth * healthPercent;
            _health.size = newScale;

            if (hp > _maxHp / 2)
            {
                _health.color = Color.green;
            }
            else
            {
                _health.color = Color.red;
            }

            if (hp <= 0)
            {
                
                // Died?.Invoke(); // ? ~ проверка на null ~ пустой делегат или нет
                Debug.Log("Enemy dead");
                
                // GameObject explosionPrefab = Instantiate(_explosion);
                // explosionPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                EnlistmentOfDestruction();
                
                Destroy(gameObject);
                EventManager.OnEnemyDied(); // Вызов метода
            }
        }

        private void EnlistmentOfDestruction()
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.EnemyDestroy();
            }
        }
    }
}