using System;
using LearningScripts;
using UnityEngine;

namespace LearningScripts
{
    public class Inheritance : MonoBehaviour
    {
        public void Awake()
        {
            //Enemy
            // EnemyWolf enemyWolf = new EnemyWolf();
            // EnemyFrog enemyFrog = new EnemyFrog();
            // EnemyDuck enemyDuck = new EnemyDuck();
            // enemyWolf.Move();
            // enemyFrog.Move();
            // enemyDuck.Move();
            
            //Person + Programmer 
            Programmer programmer = new Programmer();
            programmer.GetInformation();
                 
            // Garage
            Car chevrolet = new Car("yellow","Chevrolet", 250); // создал экземпляр класса
            Car corvette = new Car("red","Corvette", 280); // изменил поля (проинициализировал объекты)
            // chevrolet.Color = "yellow";  
            // corvette.Color = "red";
            chevrolet.Drive();// вызвал метод езды
            corvette.Drive();
            // corvette.Initialize("red","Corvette", 280);
        }
    }

    // BaseParent
    public abstract class Enemy
    {
        public int MoveSpeed { get; protected set; }

        public Enemy(int moveSpeed)
        {
            MoveSpeed = moveSpeed; // инициализация поля
        }

        public abstract void Move();

    }

    public class EnemyWolf : Enemy
    {
        public EnemyWolf(int moveSpeed) : base(moveSpeed) // инициализвция общего поля базового класса
        {
        }
        public override void Move()
        {
            MoveSpeed = 20;
            // base.Move();
            Debug.Log($"Wolf - move speed {MoveSpeed}");
        }
    }
    public class EnemyFrog : Enemy
    {
        public EnemyFrog(int moveSpeed) : base(moveSpeed) // инициализвция общего поля базового класса
        {
            
        }
        public override void Move()
        {
            MoveSpeed = 5;
            Debug.Log($"Frog - move speed {MoveSpeed}");
        }
    }
    public class EnemyDuck : Enemy
    {
        public EnemyDuck(int moveSpeed) : base(moveSpeed) // инициализвция общего поля базового класса
        {
            
        }
        public override void Move()
        {
            MoveSpeed = 30;
            Debug.Log($"Duck - move speed {MoveSpeed}");
        }
    }
    
    public class Person
    {
        public int Age { get; set; } = 39; // protected - доступ только в самом класе и наследниках
        public string FirstName { get; set; } = "John";
        public string LastName { get; set; } = "Carter";
        // protected int Age = 39; // protected - доступ только в самом класе и наследниках
        // protected string FirstName = "John";
        // protected string LastName = "Carter";
    }
    public class Car
    {
        private string _color;
        private string _model;
        private int _maxSpeed;

        public Car(int maxSpeed) // конструктор, инициализирует поле "_maxSpeed" с помощью переданого параметра
        {
            _maxSpeed = maxSpeed;
        }
        public Car(string color, string model, int maxSpeed): this(maxSpeed) // для вызова актуального конструктора
        {
            _color = color;
            _model = model;
        }
        
        public void Drive()
        {
            Debug.Log($"{_model} - {_color} color - MaxSpeed ({_maxSpeed} km/h)");
        }

        // public void Initialize(string color, string model, int maxSpeed) // инициализирующий метод
        // {
        //     _color = color;
        //     _model = model;
        //     _maxSpeed = maxSpeed;
        // }
    }

    // DerivedChild
    public class Programmer : Person
    {
        public void GetInformation()
        {
            Debug.Log($"{FirstName} {LastName} - {Age} years");
        }
    }
}