using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LearningScripts.FirstGame
{
    // 10) У нас есть один игрок
    //     На него постоянно идут враги, враги разного типа: бот, танк, самолет.
    //     Игрок может стрелять по врагам и наносить им некоторый урон
    //     Бот ничем не выделяется, у него есть только здоровье. 
    //     У танка есть броня, Которая уменьшает прямо урон на количество очков брони.
    //     У самолета есть 33 процента шанс увернуться от урона и не получить его вообще.
    //     Брони у самолета нет.

    // 10.1) Создаем класс, который раз в x секунд создает врага
    //       - x выбирается случайно от 1 до 3
    //       - Враг начинает двигаться по прямой всегда в одном направлении
    //       - Когда враг проходит x метров, он самоуничтожается
    //       Добавляем логику “смерти”. При смерти обьект врага уничтожается. Смерть наступает, когда заканчивается HP

    // 10.2) На пути врага куда-нибудь ставим обьект “игрока”, он находится в одном месте и не двигается.
    //       Игрок постоянно “ищет” врагов. Как только враг найдет, 
    //       игрок поворачивается в сторону найденного врага и “смотрит” на него до тех пор, 
    //       пока враг не умрет или не самоуничтожится, после этого игрок фокусируется на новом враге.
    //       По нажатию на кнопку игрок “стреляет” во врага, на котором он сфокусирован, нанося ему урон.
    
    // 10.3) Добавляем индикатор здоровья врагам. Можно сделать любым способом, какой захочется.
    //       Добавляем возможность настраивать здоровье противников, их скорость и урон игрока из Юнити.
    //       Добавляем индикатор очков, игрок зарабывает 1 очко за убийство врага
    //       Игра заканчивается через 60 секунд, появляется окно с поздравлением о победе, если мы набрали больше 10 очков или проигрыше, если нет.
    //       Добавляем любую анимацию/систему частиц/индикацию выстрела игрока.

    
    public class Game : MonoBehaviour // класс управляющий игровой логикой
    {
        [SerializeField] private Enemy _enemyPrefab; // Префаб врага, который будет создаваться
        [SerializeField] private Player _playerPrefab; // Префаб игрока, экземпляр объекта с настройками и компонентами
        
        private float _time = 0.0f; // Переменная для отслеживания времени
        public float InterpolationPeriod = 3; // Переменная интервала между созданиями врагов

        public void Start() // Инициализация объекта Player в момент его активации
        {
            _playerPrefab.transform.localPosition = new Vector3(0f, 0f, 0f); // Позиция игрока на поле (transform - компонент объекта с позицией, поворотом и масштабом)
            
        }
        
        public void Update() // Обновление ~ вызывается каждый кадр
        {
            // if (Player.EnemyDetectionRadius <= _enemyPrefab.transform.position
            // {
            //     
            // }

            // _enemyPrefab.transform.position = Random.Range(new Vector3(Random.value, Random.value, Random.value));
            
            _time += Time.deltaTime; // Увеличить время

            if (_time >= InterpolationPeriod) // Если прошло достаточно времени ...
            {
                _time = 0; // Сбрасывание времени
                Instantiate(_enemyPrefab); // Создание нового врага на основе префаба
                // execute block of code here
            }
        }
    }

    public class Player : MonoBehaviour // Класс, представляющий игрока
    {
        public int PlayerHP { get; protected set; }
        public int PlayerArmor;
        public int DamageFromPlayer; // Урон, наносимый игроком
        public float EnemyDetectionRadius = 20f;

        public void PlayerShoot(Enemy enemy) // Метод, вызываемый при выстреле игрока (Player)
        {
            enemy.GetDamageFromPlayer(DamageFromPlayer); // Метод нанесения урона врагу (Enemy)
        }

        public void GetDamageFromEnemy(int damageFromEnemy) // Метод для получения урона гроком (Player)
        {
            if (PlayerArmor > 0) // Если у игрока есть броня
            {
                damageFromEnemy -= PlayerArmor; // Уменьшить броню на количество урона 
            }

            PlayerHP -= damageFromEnemy; // Нанести урон здоровью игрока
        }
    }

    public class Enemy : MonoBehaviour // Класс, представляющий врага (Enemy)
    {
        public Vector3 InitialPosition; // Начальная позиция врага (Enemy)
        public float Speed; // Скорость движения врага
        public int DamageFromEnemy; // Урон, наносимый врагом

        public int EnemyHP { get; protected set; }
        public int EnemyArmor;
        public float ChanceEnemyToEvade; // Шанс врага увернуться

        public class EnemiesTypes
        {
            public List<Enemy> EnemiesOfDifferentTypes = new List<Enemy>(); // Динамический список врагов разного типа
            
            public class Bot // Класс, представляющий врага типа Bot
            {
                public int Hp = 100;
                public int Damage = 10;
                public float Speed = 5f;
            }

            public class Tank // Класс, представляющий врага типа Tank
            {
                public int Hp = 100;
                public int Armor = 100;
                public int Damage = 30;
                public float Speed = 30f;
            }

            public class AirPlane // Класс, представляющий врага типа AirPlane
            {
                public int Hp = 100;
                public int Damage = 20;
                public float Speed = 50f;
            }
        }

        public void Update() 
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * Speed));  // Перемещение врага вперед с заданной скоростью
        }
        
        public void EnemyShoot(Player player) // Метод, вызываемый при выстреле врага (Enemy)
        {
            player.GetDamageFromEnemy(DamageFromEnemy); // Метод нанесения урона Игроку (Player)
        }

        public void GetDamageFromPlayer(int damageFromPlayer) // Метод для получения урона врагом (Enemy)
        {
            int random = Random.Range(1, 101);
            
            if (ChanceEnemyToEvade <= 0)    // Проверить возможность уворота врага (и если шанс уворота не положителен)
            {
                if (random > ChanceEnemyToEvade) // Проверить случайное число (от 1 до 100)
                {
                    return; // Враг увернулся от атаки
                }
            }

            if (random > 33)
            {
                if (EnemyArmor > 0) // Если у врага есть броня
                {
                    EnemyArmor -= damageFromPlayer; // Уменьшить броню на количество урона 
                }
                else
                {
                    EnemyHP -= damageFromPlayer; // Нанести урон здоровью врага 
                }
            }

            if (EnemyArmor > 0) // Если у врага есть броня
            {
                damageFromPlayer -= EnemyArmor; // Уменьшить броню на количество урона 
            }

            EnemyHP -= damageFromPlayer; // Нанести урон здоровью врага 
        }
    }
}