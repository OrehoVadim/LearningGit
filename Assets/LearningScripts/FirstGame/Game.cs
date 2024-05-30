using System.Collections.Generic;
using UnityEngine;

namespace LearningScripts.FirstGame
{
    public class Game : MonoBehaviour
    {
        public void Awake()
        {
            List<Enemy.Bot> bots = new List<Enemy.Bot>();
            bots.Add(new Enemy.Bot(100, 10));
            List<Enemy.Tank> tanks = new List<Enemy.Tank>();
            tanks.Add(new Enemy.Tank(100, 100, 30));
            List<Enemy.AirPlane> airPlanes = new List<Enemy.AirPlane>();
            airPlanes.Add(new Enemy.AirPlane(100, 20));
            
            // bots[0].Hp = (bots[0].Hp);
            // Debug.Log(bots[0].Hp);
            //
            // tanks[0].Hp = (tanks[0].Hp);
            // // tanks[0].TankDamage(player.Damage);
            // Debug.Log(tanks[0].Armor);
            //
            // airPlanes[0].Hp = (airPlanes[0].Hp);
            // Debug.Log(airPlanes[0].Hp);
        }
    }
    // У нас есть один игрок
    // На него постоянно идут враги, враги разного типа: бот, танк, самолет.
    // Игрок может стрелять по врагам и наносить им некоторый урон
    // Бот ничем не выделяется, у него есть только здоровье. 
    // У танка есть броня, Которая уменьшает прямо урон на количество очков брони.
    // У самолета есть 33 процента шанс увернуться от урона и не получить его вообще.
    // Брони у самолета нет.
    
    // public abstract class Enemy // абстрактный клас врагов
    // {
    //     
    // }
    
    // public class EnemyCreator
    // {
    //     
    // }
    
    // Создать абстрактный класс "Стрелять" с виртуальным методом "Выстрел" и полем урон
    public abstract class ObjectFeatures //Особенности объектов
    {
        // Определять тип обекта и передавать орудие которое он использует в метод для вычисления урона
        public abstract void ObjectDamage(int weaponDamage);
        
        // Наносить урон всем
        // Использовать разное орудие с разним уроном, в зависимости от объекта
        public virtual void Shoot(int weaponDamage)
        {
            // Dictionary<string, int> gameObject = new Dictionary<string, int>();
            // gameObject.Add("Player", 10);
            // gameObject.Add("Bot", 10);
            // gameObject.Add("Tank", 20);
            // gameObject.Add("AirPlane", 30);

            foreach (var value in Enemy.Enemies)
            {
                Debug.Log(value);
                // if (value.GetType() == typeof(Bot))
                // {
                //     value = weaponDamage 
                // }
            }
        }
        
        // public abstract void Movement();
    }
    
    public class Player : ObjectFeatures
    {
        private int Hp { get; set; }
        private int GunDamage { get; set; }

        public Player(int hp, int gunDamage)
        {
            Hp = 100;
            GunDamage = 10;
        }
        
        public override void ObjectDamage(int weaponDamage){}
        
        
        public  int Shoot(int weaponDamage)
        {
            return Hp -= weaponDamage;
        }
    }

    
    public class Enemy // клас для всех врагов
    {
        public static List<Enemy> Enemies = new List<Enemy>();

        public void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
            Debug.Log(Enemies);
        }

        public void CheckEnemy()
        {
            foreach (var enemy in Enemies)
            {
                Debug.Log(enemy);
            }
        }

        public class Bot : ObjectFeatures
        {
            private int Hp { get; set; } 
            private int GunDamage { get; set; }

            public Bot(int hp, int gunDamage)
            {
                Hp = 100;
                GunDamage = 20;
            }

            public override void ObjectDamage(int weaponDamage)
            {
                Hp -= weaponDamage;
            }

            public void Movement()
            {
            }
        }

        public class Tank : ObjectFeatures
        {
            private int Hp { get; set; }
            private int Armor{ get; set; }
            private int CannonDamage { get; set; }

            public Tank(int hp, int armor, int cannonDamage)
            {
                Hp = 100;
                Armor = 100;
                CannonDamage = 30;
            }

            public override void ObjectDamage(int weaponDamage)
            {
                if (Armor >= 0)
                {
                    Armor -= weaponDamage;
                }
                else
                {
                    Hp -= weaponDamage;
                }
            }
        }

        public class AirPlane : ObjectFeatures
        {
            private int Hp { get; set; }
            private int MachineGunDamage { get; set; }

            public AirPlane(int hp, int machineGunDamage)
            {
                Hp = 100;
                MachineGunDamage = 20;
            }

            public override void ObjectDamage(int weaponDamage)
            {
                int random = Random.Range(1, 101);
                if (random > 33)
                {
                    Hp -= weaponDamage;
                }
            }
        }
    }
}