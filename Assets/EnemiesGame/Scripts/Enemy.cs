using UnityEngine;
using UnityEngine.UIElements;

namespace EnemiesGame
{
    public class Enemy : MonoBehaviour // Класс, представляющий врага (Enemy)
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _armor;
        [SerializeField] private float _chanceToEvade = 33; // Шанс врага увернуться
        [SerializeField] private float _speed; // Скорость движения врага

        private bool _evaded;

        // public Slider enemyHealthBar;

        public void Update() 
        {
            transform.Translate(Vector3.down * (Time.deltaTime * _speed));  // Перемещение врага вперед с заданной скоростью
            if (_evaded)
            {
                var vectorToEvade = Random.Range(1, 3) == 1 ? Vector3.left : Vector3.right;
                transform.Translate(vectorToEvade * 0.25f );
                _evaded = false;
            }
        }

        // public void SetValueHealthBar()
        // {
        //     enemyHealthBar.value = _hp;
        // }
        
        public void GetDamage(int damage) // Метод для получения урона врагом (Enemy)
        {
            int random = Random.Range(1, 101);
            
            if (_chanceToEvade > 0)    // Проверить возможность уворота врага (и если шанс уворота не положителен)
            {
                if (random > _chanceToEvade) // Проверить случайное число (от 1 до 100)
                {
                    _evaded = true;
                    return; // Враг увернулся от атаки
                }
            }

            if (_armor > 0) // Если у врага есть броня
            {
                damage -= _armor; // Уменьшить броню на количество урона 
            }
            
            _hp -= damage; // Нанести урон здоровью врага 
            

            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
