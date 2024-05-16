using UnityEngine;

namespace LearningScripts
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

    public class FirstGame
    {
        public abstract class Features
        {
            
            public virtual void Movement()
            {
            }
            
            public class Speed 
            {
            }
            
            public class Damage 
            {
            }
            
            public abstract class Weapon
            {
                private int Knife = 5;
                private int Gun = 15;
                private int ShotGun = 20;
                private int Grenade = 25;
                private int MachineGun = 15;
                private int Cannon = 15;
            }
        }

        public class Player
        {
            private int Hp = 100;
            private int Speed = 5;
            private int Armor = 100;
            
            public  void Movement()
            {
            }

            public  class Damage 
            {
            }

            public void CheckInfo()
            {
            }

        }

        public class Bot
        {
            private int Hp = 100;
            private int Speed = 5;
            private int Armor = 100;
            
            public  void Movement()
            {
            }

            public  class Damage 
            {
            }

        }
            
        public class Tank
        {
            private int Hp = 100;
            private int Speed = 30;
            private int Armor = 100;
            
            public  void Movement()
            {
            }

            public  class Damage 
            {
            }

        }
            
        public class Airplane
        {
            private int Hp = 100;
            private int Speed = 100;
            private int Armor = 100;
            
            public  void Movement()
            {
            }

            public  class Damage 
            {
            }

        }
    }
}