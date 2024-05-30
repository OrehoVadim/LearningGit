using System;
using UnityEngine;

namespace LearningScripts
{
    public class CalculateFigureVolume : MonoBehaviour
    {
        public void Awake()
        {
            // Task №1.2
            Figure coneFigure = new ConeFigure(6, 6); // экземпляр класса Figure (Наследование)
            float coneVolume = Geometry.CalculateFigureVolume(coneFigure);
            Debug.Log(coneVolume);
        
            Figure cylinderFigure = new CylinderFigure(0, 6);
            float cylinderVolume = Geometry.CalculateFigureVolume(cylinderFigure);
            Debug.Log(cylinderVolume);
        
            Figure ballFigure = new BallFigure(6, 6);
            float ballVolume = Geometry.CalculateFigureVolume(ballFigure);
            Debug.Log(ballVolume);
        
            Figure cubeFigure = new CubeFigure(-5);
            float cubeVolume = Geometry.CalculateFigureVolume(cubeFigure);
            Debug.Log(cubeVolume);
        }
    }
    
    public abstract class Figure // абстрактный контракт взаимодействия - далее можно переиспользовать в наследниках (объект не создается)
    {
        /// <summary>
        /// 1.2) Усовершенствовать задачу 1.1.
        /// Написать метод для подсчета обьема фигуры,
        /// в зависимости от ее типа (конус, цилиндр, шар, квадрат).
        /// Добавить всевозможные проверки.
        /// Входные данные: конус (радиус, высота), цилиндр(), шар(), квадрат()
        /// Алгоритм: создать метод с формулами для подсчета объёма указанных фигур
        /// Результат: объём указанных фигур
        /// </summary> 
        public virtual float CalculateVolume() // метод, который нужно переопределять в каждом классе-наследнике - новая реализация (Полиморфизм)
        {
            return 0;
        }
    }

    public class Geometry
    {
        public static float CalculateFigureVolume(Figure figure) // принимает объект типа Figure и вызывает метод CalculateVolume для расчета объема фигуры
        {
            // проверка на равно null, отрицательное значение
            // if (figure == null)
            // {
            //     Debug.Log("Figure cannot be null!");
            // }
            // if (figure is ConeFigure) // проверка на тип фигуры
            // {
            //     ConeFigure cone = (ConeFigure) figure; // приведение типа объекта figure к типу ConeFigure (со свойствам и методам)
            //     if (cone.Radius <= 0 || cone.Height <= 0)   
            //     {
            //         Debug.Log("\"Cone\" radius and height must be above than zero!");
            //     }
            // }
            // if (figure is CylinderFigure) 
            // {
            //     CylinderFigure cylinder = (CylinderFigure) figure;
            //     if (cylinder.Radius <= 0 || cylinder.Height <= 0)   
            //     {
            //         Debug.Log("\"Cylinder\" - radius and height must be above than zero!");
            //     }
            // }
            // if (figure is BallFigure)
            // {
            //     BallFigure ball = (BallFigure) figure;
            //     if (ball.Radius <= 0 || ball.Height <= 0)   
            //     {
            //         Debug.Log("\"Ball\" - radius and height must be above than zero!");
            //     }
            // }
            // if (figure is CubeFigure)
            // {
            //     CubeFigure cube = (CubeFigure)figure;
            //     if (cube.Length <= 0)   
            //     {
            //         Debug.Log("\"Cube\" - radius and height must be above than zero!");
            //     }
            // }
            return figure.CalculateVolume();
        }
    }

    public class ConeFigure : Figure // класс-наследник реализует метод CalculateVolume
    {
        public float Radius { get; private set; } // свойства (аксессоров get и set) (Инкапсуляция данных)
        public float Height { get; private set; } // инкапсуляция (get - извлечение данных; set - присвоение данных) (Инкапсуляция данных)

        public ConeFigure(float radius, float height)
        {
            // if (radius <= 0 || height <= 0)
            // {
            //     Debug.Log("Radius and height must be above than zero!");
            // }
            Radius = radius;
            Height = height; 
        }
        
        public override float CalculateVolume() // переопределенный метод - новая реализация (Полиморфизм - переопределение методов)
        {
            return 1f / 3f * (float)Math.PI * (Radius * Radius) * Height;
        }
    }

    public class CylinderFigure : Figure
    {
        public float Radius { get; private set; }
        public float Height { get; private set; }
        
        public CylinderFigure(float radius, float height)
        {
            // if (radius <= 0 || height <= 0)
            // {
            //     Debug.Log("Radius and height must be above than zero!");
            // }
            Radius = radius;
            Height = height;
        }
        
        public override float CalculateVolume()
        {
            return (float)Math.PI * (Radius * Radius) * Height;
        }
    }

    public class BallFigure : Figure
    {
        public float Radius { get; private set; }
        public float Height { get; private set; }

        public BallFigure(float radius, float height)
        {
            // if (radius <= 0 || height <= 0)
            // {
            //     Debug.Log("Radius and height must be above than zero!");
            // }
            Radius = radius;
            Height = height;
        }
        
        public override float CalculateVolume()
        {
            return (3f / 4f * (float)Math.PI * (Radius * Radius) * Height);
        }
    }

    public class CubeFigure : Figure

    {
        public float Length { get; private set; }

        public CubeFigure(float length)
        {
            // if (length <= 0)
            // {
            //     Debug.Log("Length must be above than zero!");
            // }
            Length = length;
        }

        public override float CalculateVolume()
        {
            return Length * Length * Length;
        }
    }
}