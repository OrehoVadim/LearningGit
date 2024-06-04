using UnityEngine;

namespace EnemiesGame
{
    public class Enemy : MonoBehaviour // Класс, представляющий врага (Enemy)
    {
        [SerializeField] private int hp;
        [SerializeField] private int armor;
        [SerializeField] private float chanceToEvade = 33; // Шанс врага увернуться
        [SerializeField] private float speed; // Скорость движения врага

        private bool _evaded;
        
        public bool IsDead2 => (hp <= 0);
        
        public bool IsDead
        {
            get { return hp <= 0; }
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
            
            if (chanceToEvade > 0)    // Проверить возможность уворота врага (и если шанс уворота не положителен)
            {
                if (random > chanceToEvade) // Проверить случайное число (от 1 до 100)
                {
                    _evaded = true;
                    return; // Враг увернулся от атаки
                }
            }

            if (armor > 0) // Если у врага есть броня
            {
                damage -= armor; // Уменьшить броню на количество урона 
            }

            hp -= damage; // Нанести урон здоровью врага 
        }
    }
}
