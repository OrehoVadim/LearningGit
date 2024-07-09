using System.Collections.Generic;
using UnityEngine;

namespace LearningScripts.FirstGame
{
    /// <summary>
    /// Входные данные:
    /// Player, Enemy-противник (Bot, Tank, Airplane)
    /// Features - (Hp, Movement, Speed, Armor-броня, Damage-урон, Weapon-оружие)
    /// Алгоритм:
    /// Создать логику игры
    /// Результат:
    /// Cоздана логика игры в соответствии с OOP
    /// </summary> 
    public partial class GamePlay
    {
        public void Awake()
        {
            List<Bot> bots = new List<Bot>();
            bots.Add(new Bot());
            List<Tank> tanks = new List<Tank>();
            tanks.Add(new Tank());
            List<AirPlane> airPlanes = new List<AirPlane>();
            airPlanes.Add(new AirPlane());

            // Player player = new Player();

            // bots[0].Hp = Bot.Shoot(bots[0].Hp);
            Debug.Log(bots[0].Hp);

            // tanks[0].Shoot(player.WeaponDamage);
            Debug.Log(tanks[0].Armor);

            // airPlanes[0].Hp = player.Shoot(airPlanes[0].Hp);
            Debug.Log(airPlanes[0].Hp);
        }
    }
        // У нас есть один игрок
        // На него постоянно идут враги, враги разного типа: бот, танк, самолет.
        // Игрок может стрелять по врагам и наносить им некоторый урон
        // Бот ничем не выделяется, у него есть только здоровье. 
        // У танка есть броня, Которая уменьшает прямо урон на количество очков брони.
        // У самолета есть 33 процента шанс увернуться от урона и не получить его вообще.
        // Брони у самолета нет.

    public class Enemys // абстрактный клас врагов
    {
        
    }

    public class EnemyCreator
    {
        
    }

    // Создать абстрактный класс "Стрелять" с виртуальным методом "Выстрел" и полем урон
    public abstract class ObjectFeatures //Особенности объектов
    {
        public int WeaponDamage;
        public int ObjectDamage;

        public virtual int Shoot(int WeaponDamage) // virtual - чтобы изменить метод базового класса у наследников
        {

            return ObjectDamage -= WeaponDamage;
        }

        public virtual float Speed { get; set; }

        public virtual void Movement()
        {
        }
    }

    public class Gamer
    {
        private int Damage = 10;
        public  int Shoot(int ObjectDamage)
        {
            return  ObjectDamage - Damage;
        }
    }

    public class Bot
    {
        public int Hp = 100;
        public int ObjectDamage = 10;

        public int Shoot(int ObjectDamage)
        {
            return Hp - ObjectDamage;
        }
    }

    public class Tank : ObjectFeatures
    {
        public int Hp = 100;
        public int Armor = 100;

        // public override void Shoot(int WeaponDamage)
        // {
        //     if (Armor >= 0)
        //     {
        //         Armor -= WeaponDamage;
        //     }
        //     else
        //     {
        //         Hp -= WeaponDamage;
        //     }
        // } 

        public override void Movement()
        {
            Speed = 30f;
        }
    }

    public class AirPlane : ObjectFeatures
    {
        public int Hp = 100;

        public override int Shoot(int weaponDamage)
        {
            int random = Random.Range(1, 101);
            if (random > 33)
            {
                Hp -= weaponDamage;
            }

            return 0;
        }

        public override void Movement()
        {
            Speed = 80f;
        }
    }
}