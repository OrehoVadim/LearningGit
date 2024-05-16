using System;

namespace LearningScripts
{
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
        public float CalculateFigureVolume(Figure figure)
        {
            return figure.CalculateVolume();
        }
        
        public virtual float CalculateVolume() // метод, который можно переопределять - новая реализация (Полиморфизм)
        {
            return 0;
        }
    }

    public class ConeFigure : Figure
    {
        public float Radius { get; private set; } // свойства (аксессоров get и set) (Инкапсуляция данных)
        public float Height { get; private set; } // инкапсуляция (get - извлечение данных; set - присвоение данных) (Инкапсуляция данных)

        public ConeFigure(float radius, float height)
        {
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
            Length = length;
        }

        public override float CalculateVolume()
        {
            return Length * Length * Length;
        }
    }
}